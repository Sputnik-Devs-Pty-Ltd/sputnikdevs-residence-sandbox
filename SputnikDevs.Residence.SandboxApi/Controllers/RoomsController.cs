using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Data;
using SputnikDevs.Residence.SandboxApi.DTOs;

namespace SputnikDevs.Residence.SandboxApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly SandboxDbContext _context;

    public RoomsController(SandboxDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
    {
        var rooms = await _context.Rooms
            .Include(r => r.Students)
            .Include(r => r.MaintenanceTickets)
            .AsNoTracking()
            .Select(r => new RoomDto(
                r.Id,
                r.BuildingName,
                r.RoomNumber,
                r.Floor,
                r.Capacity,
                r.Students.Count,
                r.Students.Count >= r.Capacity,
                r.MaintenanceTickets.Count(t => t.Status != Domain.Enums.TicketStatus.Resolved && t.Status != Domain.Enums.TicketStatus.Closed)
            ))
            .ToListAsync();

        return Ok(rooms);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RoomDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoomDto>> GetRoomById(Guid id)
    {
        var room = await _context.Rooms
            .Include(r => r.Students)
            .Include(r => r.MaintenanceTickets)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        if (room == null)
            return NotFound(new { message = $"Room with ID '{id}' was not found." });

        return Ok(new RoomDto(
            room.Id,
            room.BuildingName,
            room.RoomNumber,
            room.Floor,
            room.Capacity,
            room.Students.Count,
            room.Students.Count >= room.Capacity,
            room.MaintenanceTickets.Count(t => t.Status != Domain.Enums.TicketStatus.Resolved && t.Status != Domain.Enums.TicketStatus.Closed)
        ));
    }
}
