using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

/// <summary>
/// Represents a maintenance ticket submitted by a student for an issue in the residence.
/// </summary>
public class MaintenanceTicket : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of the ticket.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ticket's description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ticket category.
    /// </summary>
    public TicketCategory Category { get; set; } = TicketCategory.Other;

    /// <summary>
    /// Gets or sets a ticket's priority.
    /// </summary>
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    /// <summary>
    /// Gets or sets a ticket's status.
    /// </summary>
    public TicketStatus Status { get; set; } = TicketStatus.Open;

    /// <summary>
    /// Gets whether the ticket has been resolved or closed.
    /// </summary>
    public bool IsClosedOrResolved =>
        Status == TicketStatus.Resolved ||
        Status == TicketStatus.Closed;

    // Student who reported the issue
    /// <summary>
    /// Gets or sets the identifier of the student who submits a ticket.
    /// </summary>
    public Guid StudentId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property for the student who submits a ticket.
    /// </summary>
    public Student? Student { get; set; }

    // Room where the issue is located
    /// <summary>
    /// Gets or sets the identifier of the room where the issue is located.
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Gets or sets the room associated with the ticket.
    /// </summary>
    public Room? Room { get; set; }

    // Resolution & Assignment tracking
    /// <summary>
    /// Gets or sets the technician assigned to the ticket, if any.
    /// </summary>
    public string? AssignedTechnician { get; set; }

    /// <summary>
    /// Gets or sets the notes describing how the issue was resolved.
    /// </summary>
    public string? ResolutionNotes { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the ticket was resolved, if applicable.
    /// </summary>
    public DateTime? ResolvedAtUtc { get; set; }

    // Comments & Audit history
    /// <summary>
    /// Gets the collection of comments associated with the ticket.
    /// </summary>
    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}
