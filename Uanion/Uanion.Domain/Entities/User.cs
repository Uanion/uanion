﻿using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class User : AuditableEntity, ISoftDeletable
{
    public Guid UserId { get; set; }

    public string Nickname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool EmailVerified { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Profile? Profile { get; set; }

    public ICollection<UserDialog>? UsersDialogs { get; set; }

    public ICollection<Message>? Messages { get; set; }

    public ICollection<ProfilePost>? ProfilePosts { get; set; }

    public bool IsDeleted { get; set; }
}
