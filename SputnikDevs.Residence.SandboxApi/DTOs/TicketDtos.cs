using System.ComponentModel.DataAnnotations;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.DTOs;

/// <summary>
/// Represents a maintenance ticket returned by the API.
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Category"></param>
/// <param name="Priority"></param>
/// <param name="Status"></param>
/// <param name="IsClosedOrResolved"></param>
/// <param name="StudentId"></param>
/// <param name="StudentName"></param>
/// <param name="RoomId"></param>
/// <param name="RoomNumber"></param>
/// <param name="BuildingName"></param>
/// <param name="AssignedTechnician"></param>
/// <param name="ResolutionNotes"></param>
/// <param name="CreatedAtUtc"></param>
/// <param name="ResolvedAtUtc"></param>
/// <param name="Comments"></param>
public record MaintenanceTicketDto(
    Guid Id,
    string Title,
    string Description,
    TicketCategory Category,
    TicketPriority Priority,
    TicketStatus Status,
    bool IsClosedOrResolved,
    Guid StudentId,
    string StudentName,
    Guid RoomId,
    string RoomNumber,
    string BuildingName,
    string? AssignedTechnician,
    string? ResolutionNotes,
    DateTime CreatedAtUtc,
    DateTime? ResolvedAtUtc,
    List<TicketCommentDto> Comments
);

/// <summary>
/// Contains the information required to create a maintenance ticket.
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Category"></param>
/// <param name="Priority"></param>
/// <param name="StudentId"></param>
/// <param name="RoomId"></param>
public record CreateMaintenanceTicketDto(
    [Required] [MaxLength(200)] string Title,
    [Required] [MaxLength(2000)] string Description,
    [Required] TicketCategory Category,
    [Required] TicketPriority Priority,
    [Required] Guid StudentId,
    [Required] Guid RoomId
);

/// <summary>
/// Contains the information required to update a maintenance ticket's status.
/// </summary>
/// <param name="Status"></param>
/// <param name="AssignedTechnician"></param>
/// <param name="ResolutionNotes"></param>
public record UpdateTicketStatusDto(
    [Required] TicketStatus Status,
    [MaxLength(100)] string? AssignedTechnician,
    [MaxLength(2000)] string? ResolutionNotes
);

/// <summary>
/// Represents a comment associated with a maintenance ticket.
/// </summary>
/// <param name="Id"></param>
/// <param name="TicketId"></param>
/// <param name="AuthorName"></param>
/// <param name="AuthorRole"></param>
/// <param name="Content"></param>
/// <param name="CreatedAtUtc"></param>
public record TicketCommentDto(
    Guid Id,
    Guid TicketId,
    string AuthorName,
    string AuthorRole,
    string Content,
    DateTime CreatedAtUtc
);

/// <summary>
/// Contains the information required to add a comment to a maintenance ticket.
/// </summary>
/// <param name="AuthorName"></param>
/// <param name="AuthorRole"></param>
/// <param name="Content"></param>
public record AddTicketCommentDto(
    [Required] [MaxLength(100)] string AuthorName,
    [Required] [MaxLength(50)] string AuthorRole,
    [Required] [MaxLength(2000)] string Content
);
