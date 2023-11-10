using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class ProfilePhotoConfiguration : IEntityTypeConfiguration<ProfilePhoto>
{
    public void Configure(EntityTypeBuilder<ProfilePhoto> builder)
    {
        builder
            .ToTable("PofilePhoto")
            .HasKey(x => x.ProfilePhotoId);

        builder
            .HasOne(x => x.Profile)
            .WithOne(p => p.ProfilePhoto)
            .HasForeignKey<ProfilePhoto>(x => x.ProfileId)
            .IsRequired();
    }
}
