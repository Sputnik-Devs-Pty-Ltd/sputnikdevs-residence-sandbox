namespace SputnikDevs.Residence.SandboxApi.Domain.Enums;

public enum TicketCategory
{
    Plumbing = 1,
    Electrical = 2,
    Carpentry = 3,
    Appliance = 4,
    Structural = 5,
    InternetWifi = 6,
    SecurityAndLocks = 7,
    Other = 99
}

public enum TicketPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Emergency = 4
}

public enum TicketStatus
{
    Open = 1,
    Assigned = 2,
    InProgress = 3,
    PendingParts = 4,
    Resolved = 5,
    Closed = 6,
    Rejected = 7
}
