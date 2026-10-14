namespace SputnikDevs.Residence.SandboxApi.Domain.Enums;

/// <summary>
/// Defines the categories of maintenance reported in the residence.
/// </summary>
public enum TicketCategory
{
    /// <summary>
    /// Plumbing issues such as leaking pipes or blocked drains.
    /// </summary>
    Plumbing = 1,

    /// <summary>
    /// Electrical faults and power-related issues.
    /// </summary>
    Electrical = 2,

    /// <summary>
    /// Carpentry and woodwork repairs.
    /// </summary>
    Carpentry = 3,

    /// <summary>
    /// Faults involving appliances.
    /// </summary>
    Appliance = 4,

    /// <summary>
    /// Structural damage to the building.
    /// </summary>
    Structural = 5,

    /// <summary>
    /// Internet connectivity and Wi-Fi issues.
    /// </summary>
    InternetWifi = 6,

    /// <summary>
    /// Security concerns and lock-related issues.
    /// </summary>
    SecurityAndLocks = 7,

    /// <summary>
    /// Pest infestations and pest control services.
    /// </summary>
    PestControl = 8,

    /// <summary>
    /// Heating, ventilation and air conditioning issues.
    /// </summary>
    HVAC = 9,

    /// <summary>
    /// Damaged or faulty furniture.
    /// </summary>
    Furniture = 10,

    /// <summary>
    /// Issues that do not fit another category.
    /// </summary>
    Other = 99
}


/// <summary>
/// Defines the urgency level of a maintenance ticket.
/// </summary>
public enum TicketPriority
{
    /// <summary>
    /// A low-urgency issue.
    /// </summary>
    Low = 1,

    /// <summary>
    /// An issue with moderate urgency.
    /// </summary>
    Medium = 2,

    /// <summary>
    /// An issue requiring prompt attention.
    /// </summary>
    High = 3,

    /// <summary>
    /// An urgent issue requiring immediate attention.
    /// </summary>
    Emergency = 4
}

/// <summary>
/// Defines the current workflow status of a maintenance ticket.
/// </summary>
public enum TicketStatus
{
    /// <summary>
    /// The ticket has been submitted and is awaiting action.
    /// </summary>
    Open = 1,

    /// <summary>
    /// The ticket has been assigned to someone.
    /// </summary>
    Assigned = 2,

    /// <summary>
    /// Work on the issue is underway.
    /// </summary>
    InProgress = 3,

    /// <summary>
    /// Work is waiting for required parts.
    /// </summary>
    PendingParts = 4,

    /// <summary>
    /// The reported ticket has been resolved.
    /// </summary>
    Resolved = 5,

    /// <summary>
    /// The ticket has been closed.
    /// </summary>
    Closed = 6,

    /// <summary>
    /// The ticket has been rejected and will not be actioned.
    /// </summary>
    Rejected = 7
}
