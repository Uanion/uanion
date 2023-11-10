using Microsoft.EntityFrameworkCore;
using Uanion.Domain.Common;
using Uanion.Domain.Entities;

namespace Uanion.Persistence;

public class UanionDbContext : DbContext
{
    public UanionDbContext(DbContextOptions<UanionDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    
    public DbSet<Dialog> Dialogs { get; set; }
    
    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<ProfilePhoto> ProfilePhotos { get; set; }

    public DbSet<ProfilePost> ProfilePosts { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UanionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entry.Entity.LastModifiedDate = DateTime.UtcNow,
                _ => null
            };
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
