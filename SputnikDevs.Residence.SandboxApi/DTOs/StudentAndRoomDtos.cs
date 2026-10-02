using System.ComponentModel.DataAnnotations;

namespace SputnikDevs.Residence.SandboxApi.DTOs;

public record StudentDto(
    Guid Id,
    string StudentNumber,
    string FirstName,
    string LastName,
    string FullName,
    string Email,
    string PhoneNumber,
    Guid? RoomId,
    string? RoomNumber,
    string? BuildingName
);

public record CreateStudentDto(
    [Required] [MaxLength(50)] string StudentNumber,
    [Required] [MaxLength(100)] string FirstName,
    [Required] [MaxLength(100)] string LastName,
    [Required] [EmailAddress] [MaxLength(150)] string Email,
    [MaxLength(30)] string PhoneNumber,
    Guid? RoomId
);

public record RoomDto(
    Guid Id,
    string BuildingName,
    string RoomNumber,
    int Floor,
    int Capacity,
    int CurrentOccupancy,
    bool IsOccupied,
    int ActiveTicketsCount
);
