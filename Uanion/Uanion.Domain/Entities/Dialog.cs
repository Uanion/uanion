using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class Dialog : AuditableEntity, ISoftDeletable
{
    public Guid DialogId { get; set; }

    public ICollection<Message>? Messages { get; set; }

    public ICollection<UserDialog>? UsersDialogs { get; set; }

    public bool IsDeleted { get; set; }
}
