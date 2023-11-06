using Uanion.Application.Contracts.Persistence;
using Uanion.Domain.Entities;

namespace Uanion.Persistence.Repositories;

public class DialogRepository : BaseRepository<Dialog>, IDialogRepository
{
    public DialogRepository(UanionDbContext dbContext) : base(dbContext)
    {
    }
}
