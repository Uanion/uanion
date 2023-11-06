using MediatR;

namespace Uanion.Application.Features.Dialog.Queries.GetDialog;

public class GetDialogQuery : IRequest<DialogViewModel>
{
    public Guid DialogId { get; set; }
}
