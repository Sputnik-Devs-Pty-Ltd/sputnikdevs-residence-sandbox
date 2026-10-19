using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;
using SputnikDevs.Residence.SandboxApi.Domain.Enums;

namespace SputnikDevs.Residence.SandboxApi.Data;

/// <summary>
/// Seeds the database with sample rooms, students
/// maintenance tickets and ticket comments.
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Ensures the database exists and seeds it with sample
    /// data if it hasn't already been seeded.
    /// </summary>
    /// <param name="context">
    /// The database context used to access and save data.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous seeding operation.
    /// </returns>
    public static async Task SeedAsync(SandboxDbContext context)
    {
        // Ensure database schema is created (apply EF Core migrations for PostgreSQL, or EnsureCreated for SQLite)
        if (context.Database.IsNpgsql())
        {
            await context.Database.MigrateAsync();
        }
        else
        {
            await context.Database.EnsureCreatedAsync();
        }

        // Checks whether any room exists.
        if (await context.Rooms.AnyAsync())
        {
            return; // DB has been seeded already
        }

        // 1. Create and save rooms.
        var room101 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "101", Floor = 1, Capacity = 2 };
        var room102 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "102", Floor = 1, Capacity = 2 };
        var room201 = new Room { BuildingName = "Gauteng Campus Residence A", RoomNumber = "201", Floor = 2, Capacity = 3 };
        var room202 = new Room { BuildingName = "Gauteng Campus Residence B", RoomNumber = "B-202", Floor = 2, Capacity = 2 };

        // Save all rooms.
        context.Rooms.AddRange(room101, room102, room201, room202);
        await context.SaveChangesAsync();

        // 2. Create and save students.
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

        // Save all students.
        context.Students.AddRange(student1, student2, student3);
        await context.SaveChangesAsync();

        // 3. Create tickets and their comments.
        var ticket1 = new MaintenanceTicket
        {
            Title = "Leaking bathroom sink faucet",
            Description = "The cold water tap in Room 101 en-suite bathroom drips constantly and does not shut off fully.",
            Category = TicketCategory.Plumbing,
            Priority = TicketPriority.Medium,
            Status = TicketStatus.Resolved,
            StudentId = student1.Id,
            RoomId = room101.Id,
            AssignedTechnician = "Muzi (Plumbing Tech)",
            CreatedAtUtc = DateTime.UtcNow.AddDays(-2),
            ResolvedAtUtc = DateTime.UtcNow,
            ResolutionNotes = "Replaced the worn faucet cartridge and tested the tap to confirm the leak had stopped."
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
            Content = "Replaced the worn faucet cartridge and tested the tap. The leak has stopped and the faucet is working normally."
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

        var ticket4 = new MaintenanceTicket
        {
            Title = "Air conditioner not cooling",
            Description = "The air conditioner in Room 102 is running but the room remains warm",
            Category = TicketCategory.HVAC,
            Priority = TicketPriority.Medium,
            Status = TicketStatus.Assigned,
            StudentId = student1.Id,
            RoomId = room102.Id,
            AssignedTechnician = "Thabo (HVAC Technician)",
            CreatedAtUtc = DateTime.UtcNow.AddHours(-8)
        };

        ticket4.Comments.Add(new TicketComment
        {
            AuthorName = "Sipho Dlamini",
            AuthorRole = "Student",
            Content = "The air conditioner has been running since this morning but is not cooling the room."
        });

        ticket4.Comments.Add(new TicketComment
        {
            AuthorName = "Thabo",
            AuthorRole = "Technician",
            Content = "Inspection scheduled to check the air filter and cooling system."
        });

        var ticket5 = new MaintenanceTicket
        {
            Title = "Ant infestation near residence kitchen",
            Description = "Ants are appearing around the kitchen cupboards and food preparation area.",
            Category = TicketCategory.PestControl,
            Priority = TicketPriority.Medium,
            Status = TicketStatus.Open,
            StudentId = student2.Id,
            RoomId = room101.Id,
            CreatedAtUtc = DateTime.UtcNow.AddHours(-4)
        };

        ticket5.Comments.Add(new TicketComment
        {
            AuthorName = "Amina Khumalo",
            AuthorRole = "Student",
            Content = "Ants have been appearing near the kitchen cupboards. The area has been cleaned but they keep returning."
        });

        var ticket6 = new MaintenanceTicket
        {
            Title = "Broken desk chair leg",
            Description = "One leg of the chair in Room 201 is damaged, making the chair unstable.",
            Category = TicketCategory.Furniture,
            Priority = TicketPriority.Low,
            Status = TicketStatus.Assigned,
            StudentId = student3.Id,
            RoomId = room201.Id,
            AssignedTechnician = "Muzi (Maintenance Technician)",
            CreatedAtUtc = DateTime.UtcNow.AddHours(-4)
        };

        ticket6.Comments.Add(new TicketComment
        {
            AuthorName = "Brian Mkandla",
            AuthorRole = "Student",
            Content = "The chair became unstable while I was using it to study. I stopped using it to avoid injury."
        });

        ticket6.Comments.Add(new TicketComment
        {
            AuthorName = "Muzi",
            AuthorRole = "Technician",
            Content = "Will inspect the chair and determine whether the leg can be repaired or the chair needs replacement."
        });

        // Save all tickets and their comments.
        context.MaintenanceTickets.AddRange(ticket1, ticket2, ticket3, ticket4, ticket5, ticket6);
        await context.SaveChangesAsync();
    }
}
