namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

public class Student : BaseEntity
{
    public string StudentNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}".Trim();

    // Foreign key to Room
    public Guid? RoomId { get; set; }
    public Room? Room { get; set; }

    // Navigation property
    public ICollection<MaintenanceTicket> MaintenanceTickets { get; set; } = new List<MaintenanceTicket>();
}
