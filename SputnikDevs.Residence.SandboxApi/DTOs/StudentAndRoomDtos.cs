using System.ComponentModel.DataAnnotations;

namespace SputnikDevs.Residence.SandboxApi.DTOs;

/// <summary>
/// Represents student information returned by the API.
/// </summary>
/// <param name="Id"></param>
/// <param name="StudentNumber"></param>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="FullName"></param>
/// <param name="Email"></param>
/// <param name="PhoneNumber"></param>
/// <param name="RoomId"></param>
/// <param name="RoomNumber"></param>
/// <param name="BuildingName"></param>
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

/// <summary>
/// Contains the information required to register a student.
/// </summary>
/// <param name="StudentNumber"></param>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
/// <param name="PhoneNumber"></param>
/// <param name="RoomId"></param>
public record CreateStudentDto(
    [Required] [MaxLength(50)] string StudentNumber,
    [Required] [MaxLength(100)] string FirstName,
    [Required] [MaxLength(100)] string LastName,
    [Required] [EmailAddress] [MaxLength(150)] string Email,
    [MaxLength(30)] string PhoneNumber,
    Guid? RoomId
);

/// <summary>
/// Represents the room information and occupancy details returned by the API.
/// </summary>
/// <param name="Id"></param>
/// <param name="BuildingName"></param>
/// <param name="RoomNumber"></param>
/// <param name="Floor"></param>
/// <param name="Capacity"></param>
/// <param name="CurrentOccupancy"></param>
/// <param name="AvailableSpots"></param>
/// <param name="IsOccupied"></param>
/// <param name="ActiveTicketsCount"></param>
public record RoomDto(
    Guid Id,
    string BuildingName,
    string RoomNumber,
    int Floor,
    int Capacity,
    int CurrentOccupancy,
    int AvailableSpots,
    bool IsOccupied,
    int ActiveTicketsCount
);
