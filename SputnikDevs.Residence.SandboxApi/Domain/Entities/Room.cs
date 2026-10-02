namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

public class Room : BaseEntity
{
    public string BuildingName { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public int Floor { get; set; }
    public int Capacity { get; set; } = 2;
    public bool IsOccupied => Students.Count >= Capacity;

    // Navigation properties
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<MaintenanceTicket> MaintenanceTickets { get; set; } = new List<MaintenanceTicket>();
}
