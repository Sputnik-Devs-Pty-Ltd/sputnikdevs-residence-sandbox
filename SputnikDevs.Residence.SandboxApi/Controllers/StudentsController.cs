using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Data;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.DTOs;

namespace SputnikDevs.Residence.SandboxApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly SandboxDbContext _context;

    public StudentsController(SandboxDbContext context)
    {
        _context = context;
    }

    private static StudentDto MapToDto(Student s) =>
        new (
            s.Id,
            s.StudentNumber,
            s.FirstName,
            s.LastName,
            s.FullName,
            s.Email,
            s.PhoneNumber,
            s.RoomId,
            s.Room?.RoomNumber,
            s.Room?.BuildingName
        );

    /// <summary>
    /// Retrieves all students in the database.
    /// </summary>
    /// <returns>Returns a 200 OK response.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
    {
        var students = await _context.Students
            .Include(s => s.Room)
            .AsNoTracking()
            .ToListAsync();

        var studentsDto = students.Select(s => MapToDto(s));

        return Ok(studentsDto);
    }

    /// <summary>
    /// Retrieves a student by their unique ID.
    /// </summary>
    /// <param name="id">Represents the student's unique ID.</param>
    /// <returns>
    /// Returns the student record if found.
    /// Returns 404 Not Found if it doesn't exist.
    /// </returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentDto>> GetStudentById(Guid id)
    {
        var student = await _context.Students
            .Include(s => s.Room)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
            return NotFound(new { message = $"Student with ID '{id}' was not found." });

        return Ok(MapToDto(student));
    }

    [HttpPost]
    [ProducesResponseType(typeof(StudentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] CreateStudentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingNumber = await _context.Students.AnyAsync(s => s.StudentNumber == dto.StudentNumber);
        if (existingNumber)
            return BadRequest(new { message = $"Student number '{dto.StudentNumber}' is already registered." });

        Room? room = null;

        if (dto.RoomId.HasValue)
        {
            room = await _context.Rooms
                 .Include(r => r.Students)
                 .FirstOrDefaultAsync(r => r.Id == dto.RoomId.Value);

            if (room is null)
            {
                return BadRequest(new
                {
                    message = $"Room '{dto.RoomId}' does not exist."
                });
            }

            if (room.AvailableSpots <= 0)
            {
                return BadRequest(new
                {
                    message = $"Room '{dto.RoomId}' has no available spots."
                });
            }
        }

        var student = new Student
        {
            StudentNumber = dto.StudentNumber.Trim(),
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Email = dto.Email.Trim().ToLowerInvariant(),
            PhoneNumber = dto.PhoneNumber?.Trim() ?? string.Empty,
            RoomId = dto.RoomId
        };

        student.Room = room;

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, MapToDto(student));
    }
}
