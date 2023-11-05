using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class DialogeConfiguration : IEntityTypeConfiguration<Dialoge>
{
    public void Configure(EntityTypeBuilder<Dialoge> builder)
    {
        builder
            .ToTable("Dialoge")
            .HasKey(x => x.DialogeId);
    }
}
