using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Configurations;

internal class DialogConfiguration : IEntityTypeConfiguration<Dialog>
{
    public void Configure(EntityTypeBuilder<Dialog> builder)
    {
        builder
            .ToTable("Dialog")
            .HasKey(x => x.DialogId);
    }
}
