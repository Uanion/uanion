using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class ProfilePost : AuditableEntity, ISoftDeletable
{
    public Guid ProfilePostId { get; set; }

    public Guid AuthorUserId { get; set; }

    public User AuthorUser { get; set; } = default!;

    public Guid ProfileId { get; set; }

    public Profile Profile { get; set; } = default!;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }
}
