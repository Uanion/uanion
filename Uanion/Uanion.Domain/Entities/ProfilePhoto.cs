using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;
public class ProfilePhoto : AuditableEntity, ISoftDeletable
{
    public Guid ProfilePhotoId { get; set; }

    public Guid ProfileId { get; set; }

    public Profile Profile { get; set; } = default!;

    public byte[] Content { get; set; } = Array.Empty<byte>();

    public bool IsDeleted { get; set; }
}
