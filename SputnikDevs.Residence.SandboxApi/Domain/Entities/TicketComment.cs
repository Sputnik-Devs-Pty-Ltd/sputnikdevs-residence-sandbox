using System.ComponentModel.DataAnnotations;

namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

/// <summary>
/// Represents a ticket comment added to a maintenance ticket.
/// </summary>
public class TicketComment : BaseEntity
{
    /// <summary>
    /// Gets or sets the identifier of the ticket the comment belongs to.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets or sets the associated maintenance ticket.
    /// </summary>
    public MaintenanceTicket? Ticket { get; set; }

    /// <summary>
    /// Gets or sets the name of the comment's author.
    /// </summary>
    [Required]
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role of the comment's author.
    /// </summary>
    public string AuthorRole { get; set; } = "Student"; // "Student", "FacilityManager", "Technician"

    /// <summary>
    /// Gets or sets the comment's text.
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;
}
