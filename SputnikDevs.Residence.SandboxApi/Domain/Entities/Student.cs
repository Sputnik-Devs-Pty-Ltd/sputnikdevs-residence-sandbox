namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

/// <summary>
/// Represents a student living in the residence.
/// </summary>
public class Student : BaseEntity
{
    /// <summary>
    /// Gets or sets a student's unique institutional number.
    /// </summary>
    public string StudentNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the student's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the student's last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the student's email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the student's contact number.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the student's first and last names.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    // Foreign key to Room
    /// <summary>
    /// Gets or sets the identifier of the student's assigned room.
    /// </summary>
    public Guid? RoomId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property for the assigned room.
    /// </summary>
    public Room? Room { get; set; }

    // Navigation property
    /// <summary>
    /// Gets tickets submitted by the student.
    /// </summary>
    public ICollection<MaintenanceTicket> MaintenanceTickets { get; set; } = new List<MaintenanceTicket>();
}
