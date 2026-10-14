namespace SputnikDevs.Residence.SandboxApi.Domain.Entities;

/// <summary>
///  Provides common identity and audit properties for domain entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the UTC date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the UTC date and time when the entity was last updated.
    /// Null if the entity has not been updated.
    /// </summary>
    public DateTime? UpdatedAtUtc { get; set; }
}
