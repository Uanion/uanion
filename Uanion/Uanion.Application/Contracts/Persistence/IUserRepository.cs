using Uanion.Domain.Entities;

namespace Uanion.Application.Contracts.Persistence;

public interface IUserRepository : IAsyncRepository<User>
{
}
