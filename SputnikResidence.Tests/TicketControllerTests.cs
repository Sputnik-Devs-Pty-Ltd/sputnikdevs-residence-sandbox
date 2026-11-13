using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SputnikDevs.Residence.SandboxApi.Controllers;
using SputnikDevs.Residence.SandboxApi.Data;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;
using SputnikDevs.Residence.SandboxApi.DTOs;

namespace SputnikResidence.Tests;

public class TicketsControllerTests
{
    // Creates a separate in-memory database for each test.
    private static SandboxDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<SandboxDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new SandboxDbContext(options);
    }

    // Creates the controller with its required dependencies.
    private static TicketsController CreateController(SandboxDbContext context)
    {
        return new TicketsController(
            context,
            NullLogger<TicketsController>.Instance);
    }

    // Creates a ticket with valid related student and room entities.
    private static MaintenanceTicket CreateTicket(
        TicketStatus status,
        string title,
        string description)
    {
        var room = new Room
        {
            Id = Guid.NewGuid(),
            BuildingName = "Test Residence",
            RoomNumber = Guid.NewGuid().ToString("N"),
            Capacity = 2
        };

        var student = new Student
        {
            Id = Guid.NewGuid(),
            StudentNumber = Guid.NewGuid().ToString("N"),
            FirstName = "Test",
            LastName = "Student",
            Email = $"{Guid.NewGuid():N}@example.com",
            PhoneNumber = "0123456789",
            Room = room
        };

        return new MaintenanceTicket
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Status = status,
            StudentId = student.Id,
            Student = student,
            RoomId = room.Id,
            Room = room,
            CreatedAtUtc = DateTime.UtcNow
        };
    }

    [Fact]
    public async Task GetTickets_FilterByStatus_ReturnsOnlyMatchingTickets()
    {
        // Arrange
        using var context = CreateContext();

        var openTicket = CreateTicket(
            TicketStatus.Open,
            "Broken tap",
            "The bathroom tap is leaking.");

        var inProgressTicket = CreateTicket(
            TicketStatus.InProgress,
            "Broken light",
            "The bedroom light is not working.");

        context.MaintenanceTickets.AddRange(openTicket, inProgressTicket);
        await context.SaveChangesAsync();

        var controller = CreateController(context);

        // Act
        var result = await controller.GetTickets(
            status: TicketStatus.InProgress);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tickets = Assert.IsAssignableFrom<IEnumerable<MaintenanceTicketDto>>(
            okResult.Value);

        var returnedTicket = Assert.Single(tickets);

        Assert.Equal(inProgressTicket.Id, returnedTicket.Id);
        Assert.Equal(TicketStatus.InProgress, returnedTicket.Status);
    }

    [Fact]
    public async Task GetTickets_FilterByStudentId_ReturnsOnlyStudentTickets()
    {
        // Arrange
        using var context = CreateContext();

        var firstStudentTicket = CreateTicket(
            TicketStatus.Open,
            "Broken window",
            "The window does not close properly.");

        var secondStudentTicket = CreateTicket(
            TicketStatus.Open,
            "Damaged cupboard",
            "The cupboard door is broken.");

        context.MaintenanceTickets.AddRange(
            firstStudentTicket,
            secondStudentTicket);

        await context.SaveChangesAsync();

        var controller = CreateController(context);

        // Act
        var result = await controller.GetTickets(
            studentId: firstStudentTicket.StudentId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tickets = Assert.IsAssignableFrom<IEnumerable<MaintenanceTicketDto>>(
            okResult.Value);

        var returnedTicket = Assert.Single(tickets);

        Assert.Equal(firstStudentTicket.Id, returnedTicket.Id);
        Assert.Equal(firstStudentTicket.StudentId, returnedTicket.StudentId);
    }

    [Fact]
    public async Task GetTickets_SearchByTitle_ReturnsMatchingTicket()
    {
        // Arrange
        using var context = CreateContext();

        var matchingTicket = CreateTicket(
            TicketStatus.Open,
            "Shower repair required",
            "The bathroom needs maintenance.");

        var unrelatedTicket = CreateTicket(
            TicketStatus.Open,
            "Broken cupboard",
            "The kitchen cupboard door is damaged.");

        context.MaintenanceTickets.AddRange(
            matchingTicket,
            unrelatedTicket);

        await context.SaveChangesAsync();

        var controller = CreateController(context);

        // Act
        var result = await controller.GetTickets(search: "shower");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tickets = Assert.IsAssignableFrom<IEnumerable<MaintenanceTicketDto>>(
            okResult.Value);

        var returnedTicket = Assert.Single(tickets);

        Assert.Equal(matchingTicket.Id, returnedTicket.Id);
    }

    [Fact]
    public async Task GetTickets_SearchByDescription_ReturnsMatchingTicket()
    {
        // Arrange
        using var context = CreateContext();

        var matchingTicket = CreateTicket(
            TicketStatus.Open,
            "Bathroom issue",
            "There is a leaking water pipe.");

        var unrelatedTicket = CreateTicket(
            TicketStatus.Open,
            "Broken cupboard",
            "The kitchen cupboard door is damaged.");

        context.MaintenanceTickets.AddRange(
            matchingTicket,
            unrelatedTicket);

        await context.SaveChangesAsync();

        var controller = CreateController(context);

        // Act
        var result = await controller.GetTickets(search: "leaking");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tickets = Assert.IsAssignableFrom<IEnumerable<MaintenanceTicketDto>>(
            okResult.Value);

        var returnedTicket = Assert.Single(tickets);

        Assert.Equal(matchingTicket.Id, returnedTicket.Id);
    }

    [Fact]
    public async Task GetTickets_InvalidStatus_ReturnsBadRequest()
    {
        // Arrange
        using var context = CreateContext();

        var controller = CreateController(context);
        var invalidStatus = (TicketStatus)999;

        // Act
        var result = await controller.GetTickets(status: invalidStatus);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task AddComment_ClosedTicket_ReturnsBadRequest()
    {
        // Arrange
        using var context = CreateContext();

        var ticket = CreateTicket(
            TicketStatus.Closed,
            "Broken door",
            "The residence door is damaged.");

        context.MaintenanceTickets.Add(ticket);
        await context.SaveChangesAsync();

        var controller = CreateController(context);

        var dto = new AddTicketCommentDto(
            "Test Student",
            "Student",
            "I would like an update on this issue.");

        // Act
        var result = await controller.AddComment(ticket.Id, dto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);

        var commentCount = await context.TicketComments.CountAsync();

        Assert.Equal(0, commentCount);
    }

    [Fact]
    public async Task AddComment_InvalidAuthorRole_ReturnsBadRequest()
    {
        // Arrange
        using var context = CreateContext();

        var ticket = CreateTicket(
            TicketStatus.Open,
            "Faulty electrical socket",
            "The socket is not working.");

        context.MaintenanceTickets.Add(ticket);
        await context.SaveChangesAsync();

        var controller = CreateController(context);

        var dto = new AddTicketCommentDto(
            "Test Student",
            "SuperAdmin",
            "Please investigate this issue.");

        // Act
        var result = await controller.AddComment(ticket.Id, dto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);

        var commentCount = await context.TicketComments.CountAsync();

        Assert.Equal(0, commentCount);
    }
}