using Uanion.Domain.Common;

namespace Uanion.Domain.Entities;

public class Message : AuditableEntity, ISoftDeletable
{
    public Guid MessageId { get; set; }

    public Guid FromUserId { get; set; }

    public User? FromUser { get; set; }

    public Guid ToDialogId { get; set; }

    public Dialog? ToDialog { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Guid? ReplyToMessageId { get; set; }

    public Message? ReplyToMessage { get; set; }

    public ICollection<Message>? ReplyMessages { get; set; }

    public bool IsRead { get; set; } = false;

    public bool IsDeleted { get; set; }
}
