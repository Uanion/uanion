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
            .IsRequired();

        builder
            .Property(x => x.Password)
            .IsRequired();

        builder
            .Property(x => x.Nickname)
            .IsRequired();

        builder
            .Property(x => x.FirstName);

        builder
            .Property(x => x.LastName);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();

        builder
            .HasIndex(x => x.Nickname);
    }
}
