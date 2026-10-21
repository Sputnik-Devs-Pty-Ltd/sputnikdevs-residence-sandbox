using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Data;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;
using SputnikDevs.Residence.SandboxApi.DTOs;

namespace SputnikDevs.Residence.SandboxApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly SandboxDbContext _context;
    private readonly ILogger<TicketsController> _logger;

    public TicketsController(SandboxDbContext context, ILogger<TicketsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// List all maintenance tickets with optional status, priority, category, or room filtering.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MaintenanceTicketDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MaintenanceTicketDto>>> GetTickets(
        [FromQuery] TicketStatus? status = null,
        [FromQuery] TicketPriority? priority = null,
        [FromQuery] TicketCategory? category = null,
        [FromQuery] Guid? roomId = null)
    {
        var query = _context.MaintenanceTickets
            .Include(t => t.Student)
            .Include(t => t.Room)
            .Include(t => t.Comments)
            .AsNoTracking();

        if (status.HasValue)
            query = query.Where(t => t.Status == status.Value);

        if (priority.HasValue)
            query = query.Where(t => t.Priority == priority.Value);

        if (category.HasValue)
            query = query.Where(t => t.Category == category.Value);

        if (roomId.HasValue)
            query = query.Where(t => t.RoomId == roomId.Value);

        var tickets = await query
            .OrderByDescending(t => t.CreatedAtUtc)
            .Select(t => MapToDto(t))
            .ToListAsync();

        return Ok(tickets);
    }

    /// <summary>
    /// Get a single ticket by its unique ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MaintenanceTicketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaintenanceTicketDto>> GetTicketById(Guid id)
    {
        var ticket = await _context.MaintenanceTickets
            .Include(t => t.Student)
            .Include(t => t.Room)
            .Include(t => t.Comments)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket == null)
            return NotFound(new { message = $"Ticket with ID '{id}' was not found." });

        return Ok(MapToDto(ticket));
    }

    /// <summary>
    /// Log a new student maintenance ticket.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(MaintenanceTicketDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaintenanceTicketDto>> CreateTicket([FromBody] CreateMaintenanceTicketDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Verify student exists
        var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
        if (!studentExists)
            return BadRequest(new { message = $"Student with ID '{dto.StudentId}' does not exist." });

        // Verify room exists
        var roomExists = await _context.Rooms.AnyAsync(r => r.Id == dto.RoomId);
        if (!roomExists)
            return BadRequest(new { message = $"Room with ID '{dto.RoomId}' does not exist." });

        var ticket = new MaintenanceTicket
        {
            Title = dto.Title.Trim(),
            Description = dto.Description.Trim(),
            Category = dto.Category,
            Priority = dto.Priority,
            Status = TicketStatus.Open,
            StudentId = dto.StudentId,
            RoomId = dto.RoomId,
            CreatedAtUtc = DateTime.UtcNow
        };

        _context.MaintenanceTickets.Add(ticket);
        await _context.SaveChangesAsync();

        // Reload to map navigation properties
        var created = await _context.MaintenanceTickets
            .Include(t => t.Student)
            .Include(t => t.Room)
            .Include(t => t.Comments)
            .FirstAsync(t => t.Id == ticket.Id);

        _logger.LogInformation("New maintenance ticket created: {TicketId} by student {StudentId}", ticket.Id, ticket.StudentId);

        return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, MapToDto(created));
    }

    /// <summary>
    /// Update the status and assignment of a ticket.
    /// </summary>
    [HttpPatch("{id:guid}/status")]
    [ProducesResponseType(typeof(MaintenanceTicketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaintenanceTicketDto>> UpdateStatus(Guid id, [FromBody] UpdateTicketStatusDto dto)
    {
        var ticket = await _context.MaintenanceTickets
            .Include(t => t.Student)
            .Include(t => t.Room)
            .Include(t => t.Comments)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket == null)
            return NotFound(new { message = $"Ticket with ID '{id}' was not found." });

        ticket.Status = dto.Status;

        if (!string.IsNullOrWhiteSpace(dto.AssignedTechnician))
            ticket.AssignedTechnician = dto.AssignedTechnician.Trim();

        if (!string.IsNullOrWhiteSpace(dto.ResolutionNotes))
            ticket.ResolutionNotes = dto.ResolutionNotes.Trim();

        if (dto.Status == TicketStatus.Resolved || dto.Status == TicketStatus.Closed)
        {
            ticket.ResolvedAtUtc ??= DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("Ticket {TicketId} updated to status {Status}", ticket.Id, ticket.Status);

        return Ok(MapToDto(ticket));
    }

    /// <summary>
    /// Add an internal comment or student update to a ticket.
    /// </summary>
    [HttpPost("{id:guid}/comments")]
    [ProducesResponseType(typeof(TicketCommentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TicketCommentDto>> AddComment(Guid id, [FromBody] AddTicketCommentDto dto)
    {
        var ticketExists = await _context.MaintenanceTickets.AnyAsync(t => t.Id == id);
        if (!ticketExists)
            return NotFound(new { message = $"Ticket with ID '{id}' was not found." });

        var comment = new TicketComment
        {
            TicketId = id,
            AuthorName = dto.AuthorName.Trim(),
            AuthorRole = dto.AuthorRole.Trim(),
            Content = dto.Content.Trim(),
            CreatedAtUtc = DateTime.UtcNow
        };

        _context.TicketComments.Add(comment);
        await _context.SaveChangesAsync();

        var commentDto = new TicketCommentDto(
            comment.Id,
            comment.TicketId,
            comment.AuthorName,
            comment.AuthorRole,
            comment.Content,
            comment.CreatedAtUtc
        );

        return CreatedAtAction(nameof(GetTicketById), new { id }, commentDto);
    }

    /// <summary>
    /// Cancel or remove an open ticket.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        var ticket = await _context.MaintenanceTickets.FirstOrDefaultAsync(t => t.Id == id);
        if (ticket == null)
            return NotFound(new { message = $"Ticket with ID '{id}' was not found." });

        _context.MaintenanceTickets.Remove(ticket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private static MaintenanceTicketDto MapToDto(MaintenanceTicket t) =>
        new(
            t.Id,
            t.Title,
            t.Description,
            t.Category,
            t.Priority,
            t.Status,
            t.IsClosedOrResolved,
            t.StudentId,
            t.Student?.FullName ?? "Unknown",
            t.RoomId,
            t.Room?.RoomNumber ?? "Unknown",
            t.Room?.BuildingName ?? "Unknown",
            t.AssignedTechnician,
            t.ResolutionNotes,
            t.CreatedAtUtc,
            t.ResolvedAtUtc,
            t.Comments.OrderBy(c => c.CreatedAtUtc).Select(c => new TicketCommentDto(
                c.Id,
                c.TicketId,
                c.AuthorName,
                c.AuthorRole,
                c.Content,
                c.CreatedAtUtc
            )).ToList()
        );
}
