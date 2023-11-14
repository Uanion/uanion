using MediatR;

namespace Uanion.Application.Features.Dialog.Queries.GetDialogsList;

public class GetDialogsListQuery : IRequest<List<DialogListViewModel>>
{
}
