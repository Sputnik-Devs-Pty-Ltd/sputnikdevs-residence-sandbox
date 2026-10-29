using System;
using System.Linq;
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
    private static readonly string[] AllowedRoles = ["Student", "Technician", "Admin"];

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
    /// Get a summary of ticket counts, grouped by status and by priority.
    /// Every status and priority is included, with a count of 0 when no tickets match.
    /// </summary>
    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var statusCounts = await _context.MaintenanceTickets
            .AsNoTracking()
            .GroupBy(t => t.Status)
            .Select(g => new { Status = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.Status, x => x.Count);
    
        var priorityCounts = await _context.MaintenanceTickets
            .AsNoTracking()
            .GroupBy(t => t.Priority)
            .Select(g => new { Priority = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.Priority, x => x.Count);
    
        var byStatus = new Dictionary<string, int>();
        foreach (TicketStatus status in Enum.GetValues<TicketStatus>())
        {
            byStatus[status.ToString()] = statusCounts.TryGetValue(status, out int count) ? count : 0;
        }
    
        var byPriority = new Dictionary<string, int>();
        foreach (TicketPriority priority in Enum.GetValues<TicketPriority>())
        {
            byPriority[priority.ToString()] = priorityCounts.TryGetValue(priority, out int count) ? count : 0;
        }
    
        return Ok(new
        {
            total = byStatus.Values.Sum(),
            byStatus,
            byPriority
        });
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
        if (!Enum.IsDefined(typeof(TicketStatus), dto.Status))
        {
            return BadRequest(new
            {
                message = $"'{dto.Status}' is not valid in ticket status."
            });
        }

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
            ticket.ResolvedAtUtc = DateTime.UtcNow;
        }
        else
        {
            ticket.ResolvedAtUtc = null;
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketCommentDto>> AddComment(Guid id, [FromBody] AddTicketCommentDto dto)
    {
        // Retrieve the full entity from the database
        var ticket = await _context.MaintenanceTickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        // Perform the null check
        if (ticket == null)
            return NotFound(new { message = $"Ticket with ID '{id}' was not found." });

        // Clean and safely extract the values inline
        string cleanAuthorName = dto.AuthorName?.Trim() ?? string.Empty;
        string cleanAuthorRole = dto.AuthorRole?.Trim() ?? string.Empty;
        string cleanContent = dto.Content?.Trim() ?? string.Empty;

        if (new[] { cleanAuthorName, cleanAuthorRole, cleanContent }.Any(string.IsNullOrEmpty))
            return BadRequest(new { message = "Author name, author role or content cannot be empty." });

        // Perform the status check
        if (ticket.Status == TicketStatus.Closed)
            return BadRequest(new { message = "Closed tickets cannot receive new comments." });

        var canonicalRole = AllowedRoles.FirstOrDefault(role => string.Equals(
                role,
                cleanAuthorRole,
                StringComparison.OrdinalIgnoreCase));

        if (canonicalRole is null)
        {
            return BadRequest(new
            {
                message = "Invalid author role. Allowed roles are Student, Technician, and Admin."
            });
        }

        var comment = new TicketComment
        {
            TicketId = id,
            AuthorName = cleanAuthorName,
            AuthorRole = canonicalRole,
            Content = cleanContent,
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
