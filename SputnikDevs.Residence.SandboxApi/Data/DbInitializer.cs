using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(SandboxDbContext context)
    {
        // Ensure database schema is created
        await context.Database.EnsureCreatedAsync();

        if (await context.Rooms.AnyAsync())
        {
            return; // DB has been seeded already
        }

        // 1. Seed Rooms
        var room101 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "101", Floor = 1, Capacity = 2 };
        var room102 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "102", Floor = 1, Capacity = 2 };
        var room201 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "201", Floor = 2, Capacity = 3 };
        var room202 = new Room { BuildingName = "Gauteng Campus Residence B", RoomNumber = "B-202", Floor = 2, Capacity = 2 };

        context.Rooms.AddRange(room101, room102, room201, room202);
        await context.SaveChangesAsync();

        // 2. Seed Students
        var student1 = new Student
        {
            StudentNumber = "STU-2026-001",
            FirstName = "Sipho",
            LastName = "Dlamini",
            Email = "sipho.d@student.sputnikdevs.local",
            PhoneNumber = "+27 82 111 2233",
            RoomId = room101.Id
        };

        var student2 = new Student
        {
            StudentNumber = "STU-2026-002",
            FirstName = "Amina",
            LastName = "Khumalo",
            Email = "amina.k@student.sputnikdevs.local",
            PhoneNumber = "+27 83 444 5566",
            RoomId = room101.Id
        };

        var student3 = new Student
        {
            StudentNumber = "STU-2026-003",
            FirstName = "Brian",
            LastName = "Mkandla",
            Email = "brian.m@student.sputnikdevs.local",
            PhoneNumber = "+27 71 777 8899",
            RoomId = room201.Id
        };

        context.Students.AddRange(student1, student2, student3);
        await context.SaveChangesAsync();

        // 3. Seed Maintenance Tickets
        var ticket1 = new MaintenanceTicket
        {
            Title = "Leaking bathroom sink faucet",
            Description = "The cold water tap in Room 101 en-suite bathroom drips constantly and does not shut off fully.",
            Category = TicketCategory.Plumbing,
            Priority = TicketPriority.Medium,
            Status = TicketStatus.Assigned,
            StudentId = student1.Id,
            RoomId = room101.Id,
            AssignedTechnician = "Muzi (Plumbing Tech)",
            CreatedAtUtc = DateTime.UtcNow.AddDays(-2)
        };

        ticket1.Comments.Add(new TicketComment
        {
            AuthorName = "Sipho Dlamini",
            AuthorRole = "Student",
            Content = "It started dripping Thursday night after the water pressure fluctuation."
        });

        ticket1.Comments.Add(new TicketComment
        {
            AuthorName = "Muzi",
            AuthorRole = "Technician",
            Content = "Inspected on Friday morning. Replacing ceramic disc washer on Monday."
        });

        var ticket2 = new MaintenanceTicket
        {
            Title = "Room study lamp electrical socket sparking",
            Description = "Wall plug socket on the left desk emitted sparks when plugging in a laptop charger.",
            Category = TicketCategory.Electrical,
            Priority = TicketPriority.Emergency,
            Status = TicketStatus.InProgress,
            StudentId = student3.Id,
            RoomId = room201.Id,
            AssignedTechnician = "Thabo (Certified Electrician)",
            CreatedAtUtc = DateTime.UtcNow.AddHours(-6)
        };

        ticket2.Comments.Add(new TicketComment
        {
            AuthorName = "Brian Mkandla",
            AuthorRole = "Student",
            Content = "Switched off breaker switch #4 on the distribution board as precaution."
        });

        var ticket3 = new MaintenanceTicket
        {
            Title = "Broken wardrobe hinge",
            Description = "Door hinge on wardrobe 2 has snapped off screws.",
            Category = TicketCategory.Carpentry,
            Priority = TicketPriority.Low,
            Status = TicketStatus.Open,
            StudentId = student2.Id,
            RoomId = room101.Id,
            CreatedAtUtc = DateTime.UtcNow.AddHours(-12)
        };

        context.MaintenanceTickets.AddRange(ticket1, ticket2, ticket3);
        await context.SaveChangesAsync();
    }
}
