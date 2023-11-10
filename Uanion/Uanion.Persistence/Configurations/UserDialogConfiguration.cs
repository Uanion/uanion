using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class UserDialogConfiguration : IEntityTypeConfiguration<UserDialog>
{
    public void Configure(EntityTypeBuilder<UserDialog> builder)
    {
        builder
            .ToTable("UserDialog")
            .HasKey(x => new { x.UserId, x.DialogId });

        builder
            .HasOne(x => x.User)
            .WithMany(u => u.UsersDialogs)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.Dialog)
            .WithMany(d => d.UsersDialogs)
            .HasForeignKey(x => x.DialogId);
    }
}
