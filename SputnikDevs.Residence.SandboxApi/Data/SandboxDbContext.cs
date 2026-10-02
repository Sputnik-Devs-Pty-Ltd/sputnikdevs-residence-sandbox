using Microsoft.EntityFrameworkCore;
using SputnikDevs.Residence.SandboxApi.Domain.Entities;

namespace SputnikDevs.Residence.SandboxApi.Data;

public class SandboxDbContext : DbContext
{
    public SandboxDbContext(DbContextOptions<SandboxDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<MaintenanceTicket> MaintenanceTickets => Set<MaintenanceTicket>();
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student configuration
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StudentNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);

            entity.HasIndex(e => e.StudentNumber).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasOne(e => e.Room)
                  .WithMany(r => r.Students)
                  .HasForeignKey(e => e.RoomId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // Room configuration
        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BuildingName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.RoomNumber).IsRequired().HasMaxLength(30);

            entity.HasIndex(e => new { e.BuildingName, e.RoomNumber }).IsUnique();
        });

        // Maintenance Ticket configuration
        modelBuilder.Entity<MaintenanceTicket>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
            entity.Property(e => e.AssignedTechnician).HasMaxLength(100);
            entity.Property(e => e.ResolutionNotes).HasMaxLength(2000);

            // Store enums as readable strings in database
            entity.Property(e => e.Category).HasConversion<string>().HasMaxLength(50);
            entity.Property(e => e.Priority).HasConversion<string>().HasMaxLength(50);
            entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(50);

            entity.HasOne(e => e.Student)
                  .WithMany(s => s.MaintenanceTickets)
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Room)
                  .WithMany(r => r.MaintenanceTickets)
                  .HasForeignKey(e => e.RoomId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Ticket Comment configuration
        modelBuilder.Entity<TicketComment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AuthorName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.AuthorRole).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Content).IsRequired().HasMaxLength(2000);

            entity.HasOne(e => e.Ticket)
                  .WithMany(t => t.Comments)
                  .HasForeignKey(e => e.TicketId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAtUtc = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
