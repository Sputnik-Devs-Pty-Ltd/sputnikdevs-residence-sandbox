namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

/// <summary>
/// Represents a room in the residence.
/// </summary>
public class Room : BaseEntity
{
    /// <summary>
    /// Gets or sets the building's name.
    /// </summary>
    public string BuildingName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a room's number.
    /// </summary>
    public string RoomNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the floor of the room.
    /// </summary>
    public int Floor { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of students the room can accommodate.
    /// </summary>
    public int Capacity { get; set; } = 2;

    /// <summary>
    /// Gets the number of available spots in the room.
    /// Returns zero if the room is at or above capacity.
    /// </summary>
    public int AvailableSpots => Math.Max(0, Capacity - Students.Count);

    /// <summary>
    /// Marks a room as occupied if the number of students
    /// in the room's collection is greater than or equal to the capacity.
    /// </summary>
    public bool IsOccupied => Students.Count >= Capacity;

    // Navigation properties
    /// <summary>
    /// Represents a collection of students in a room.
    /// </summary>
    public ICollection<Student> Students { get; set; } = new List<Student>();

    /// <summary>
    /// Represents the tickets submitted by students in the room.
    /// </summary>
    public ICollection<MaintenanceTicket> MaintenanceTickets { get; set; } = new List<MaintenanceTicket>();
}
