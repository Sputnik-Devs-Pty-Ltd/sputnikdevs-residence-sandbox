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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
    {
        var students = await _context.Students
            .Include(s => s.Room)
            .AsNoTracking()
            .Select(s => new StudentDto(
                s.Id,
                s.StudentNumber,
                s.FirstName,
                s.LastName,
                s.FullName,
                s.Email,
                s.PhoneNumber,
                s.RoomId,
                s.Room != null ? s.Room.RoomNumber : null,
                s.Room != null ? s.Room.BuildingName : null
            ))
            .ToListAsync();

        return Ok(students);
    }

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

        return Ok(new StudentDto(
            student.Id,
            student.StudentNumber,
            student.FirstName,
            student.LastName,
            student.FullName,
            student.Email,
            student.PhoneNumber,
            student.RoomId,
            student.Room?.RoomNumber,
            student.Room?.BuildingName
        ));
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

        var student = new Student
        {
            StudentNumber = dto.StudentNumber.Trim(),
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Email = dto.Email.Trim().ToLowerInvariant(),
            PhoneNumber = dto.PhoneNumber?.Trim() ?? string.Empty,
            RoomId = dto.RoomId
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, new StudentDto(
            student.Id,
            student.StudentNumber,
            student.FirstName,
            student.LastName,
            student.FullName,
            student.Email,
            student.PhoneNumber,
            student.RoomId,
            null,
            null
        ));
    }
}
