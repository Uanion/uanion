using Uanion.Application.Contracts.Persistence;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(UanionDbContext dbContext) : base(dbContext)
    {
    }
}
