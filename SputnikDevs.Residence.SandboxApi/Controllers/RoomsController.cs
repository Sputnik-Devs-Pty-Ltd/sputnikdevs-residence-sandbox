using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Data;
using SputnikDevs.Residence.SandboxApi.DTOs;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;

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

    private static RoomDto MapToDto(Room r) =>
        new (
            r.Id,
            r.BuildingName,
            r.RoomNumber,
            r.Floor,
            r.Capacity,
            r.Students.Count,
            r.AvailableSpots,
            r.IsOccupied,
            r.MaintenanceTickets.Count(t => t.Status is not Domain.Enums.TicketStatus.Resolved and not Domain.Enums.TicketStatus.Closed)
        );

    /// <summary>
    /// Retrieves all rooms from the database.
    /// </summary>
    /// <returns>
    /// Returns all rooms retrieved and a 200 OK response.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
    {
        var rooms = await _context.Rooms
            .Include(r => r.Students)
            .Include(r => r.MaintenanceTickets)
            .AsNoTracking()
            .ToListAsync();

        var roomsDto = rooms.Select(r => MapToDto(r)).ToList();
        return Ok(roomsDto);
    }

    /// <summary>
    /// Retrieves a room by its unique ID.
    /// </summary>
    /// <param name="id">Represents the room's unique ID.</param>
    /// <returns>
    /// Returns the room record if its found.
    /// Returns 404 Not Found if its not found.
    /// </returns>
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

        return Ok(MapToDto(room));
    }
}