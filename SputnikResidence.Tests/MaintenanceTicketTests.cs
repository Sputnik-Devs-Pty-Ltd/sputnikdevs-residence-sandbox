using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikResidence.Tests;

public class MaintenanceTicketTests
{
    [Theory]
    [InlineData(TicketStatus.Open, false)]
    [InlineData(TicketStatus.Assigned, false)]
    [InlineData(TicketStatus.InProgress, false)]
    [InlineData(TicketStatus.PendingParts, false)]
    [InlineData(TicketStatus.Resolved, true)]
    [InlineData(TicketStatus.Closed, true)]
    [InlineData(TicketStatus.Rejected, false)]
    public void IsClosedOrResolved_ReturnsExpectedValue(TicketStatus status, bool expected)
    {
        var ticket = new MaintenanceTicket { Status = status };

        var result = ticket.IsClosedOrResolved;

        Assert.Equal(expected, result);
    }
}