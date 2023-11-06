using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class Profile : AuditableEntity
{
    public Guid ProfileId { get; set; }

    public Guid UserId { get; set; }
}
