using Uanion.Application.Contracts.Persistence;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Repositories;

public class DialogeRepository : BaseRepository<Dialoge>, IDialogeRepository
{
    public DialogeRepository(UanionDbContext dbContext) : base(dbContext)
    {
    }
}
