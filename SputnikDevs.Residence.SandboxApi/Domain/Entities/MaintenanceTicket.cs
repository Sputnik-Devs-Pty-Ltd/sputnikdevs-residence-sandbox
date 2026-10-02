using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

public class MaintenanceTicket : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketCategory Category { get; set; } = TicketCategory.Other;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public TicketStatus Status { get; set; } = TicketStatus.Open;

    // Student who reported the issue
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }

    // Room where the issue is located
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    // Resolution & Assignment tracking
    public string? AssignedTechnician { get; set; }
    public string? ResolutionNotes { get; set; }
    public DateTime? ResolvedAtUtc { get; set; }

    // Comments & Audit history
    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}
