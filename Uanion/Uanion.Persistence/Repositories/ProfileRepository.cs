using Uanion.Application.Contracts.Persistence;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Repositories;

public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{
    public ProfileRepository(UanionDbContext dbContext) : base(dbContext)
    {
    }
}
