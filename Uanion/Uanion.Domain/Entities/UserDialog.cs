
using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class UserDialog : AuditableEntity, ISoftDeletable
{
    public Guid UserId { get; set; }

    public User User { get; set; } = default!;

    public Guid DialogId { get; set; }

    public Dialog Dialog { get; set; } = default!;

    public bool IsDeleted { get; set; }
}
