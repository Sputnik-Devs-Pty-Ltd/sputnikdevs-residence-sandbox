using System.ComponentModel.DataAnnotations;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.DTOs;

public record MaintenanceTicketDto(
    Guid Id,
    string Title,
    string Description,
    TicketCategory Category,
    TicketPriority Priority,
    TicketStatus Status,
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

public record CreateMaintenanceTicketDto(
    [Required] [MaxLength(200)] string Title,
    [Required] [MaxLength(2000)] string Description,
    [Required] TicketCategory Category,
    [Required] TicketPriority Priority,
    [Required] Guid StudentId,
    [Required] Guid RoomId
);

public record UpdateTicketStatusDto(
    [Required] TicketStatus Status,
    [MaxLength(100)] string? AssignedTechnician,
    [MaxLength(2000)] string? ResolutionNotes
);

public record TicketCommentDto(
    Guid Id,
    Guid TicketId,
    string AuthorName,
    string AuthorRole,
    string Content,
    DateTime CreatedAtUtc
);

public record AddTicketCommentDto(
    [Required] [MaxLength(100)] string AuthorName,
    [Required] [MaxLength(50)] string AuthorRole,
    [Required] [MaxLength(2000)] string Content
);
