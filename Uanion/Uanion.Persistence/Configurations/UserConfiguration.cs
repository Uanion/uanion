using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User")
            .HasKey(x => x.UserId);

        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Nickname)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(255);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(255);
    }
}
