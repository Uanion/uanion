using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class ProfilePostConfiguration : IEntityTypeConfiguration<ProfilePost>
{
    public void Configure(EntityTypeBuilder<ProfilePost> builder)
    {
        builder
            .ToTable("ProfilePost")
            .HasKey(x => x.ProfilePostId);

        builder
            .HasOne(x => x.AuthorUser)
            .WithMany()
            .HasForeignKey(x => x.AuthorUserId)
            .IsRequired();

        builder
            .HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey(x => x.ProfileId)
            .IsRequired();

        builder
            .Property(x => x.Timestamp)
            .IsRequired();
    }
}
