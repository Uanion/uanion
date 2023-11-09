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
            .WithMany(u => u.ProfilePosts)
            .HasForeignKey(x => x.AuthorUserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Profile)
            .WithMany(p => p.ProfilePosts)
            .HasForeignKey(x => x.ProfileId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(x => x.Timestamp)
            .IsRequired();
    }
}
