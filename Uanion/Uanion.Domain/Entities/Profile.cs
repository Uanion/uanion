using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class Profile : AuditableEntity, ISoftDeletable
{
    public Guid ProfileId { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public ProfilePhoto? ProfilePhoto { get; set; }

    public ICollection<ProfilePost>? ProfilePosts { get; set; }

    public bool IsDeleted { get; set; }
}
