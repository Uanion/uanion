using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder) 
    {
        builder
            .ToTable("Message")
            .HasKey(x => x.MessageId);

        builder
            .HasOne(x => x.FromUser)
            .WithMany(u => u.Messages)
            .HasForeignKey(x => x.FromUserId)
            .IsRequired();

        builder
            .HasOne(x => x.ToDialog)
            .WithMany(d => d.Messages)
            .HasForeignKey(x => x.ToDialogId)
            .IsRequired();

        builder
            .Property(x => x.Content)
            .HasMaxLength(4096);

        builder
            .Property(x => x.Timestamp)
            .IsRequired();

        builder
            .HasOne(x => x.ReplyToMessage)
            .WithMany(x => x.ReplyMessages)
            .HasForeignKey(x => x.ReplyToMessageId);
    }
}
