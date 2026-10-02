namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

public class TicketComment : BaseEntity
{
    public Guid TicketId { get; set; }
    public MaintenanceTicket? Ticket { get; set; }

    public string AuthorName { get; set; } = string.Empty;
    public string AuthorRole { get; set; } = "Student"; // "Student", "FacilityManager", "Technician"
    public string Content { get; set; } = string.Empty;
}
