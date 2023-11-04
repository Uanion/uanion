using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class User : AuditableEntity
{
    public Guid UserId { get; set; }

    public string Nickname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool EmailVerified { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
