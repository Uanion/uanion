using MediatR;

namespace Uanion.Application.Features.Dialog.Commands.UpdateDialog;

public class UpdateDialogCommand : IRequest
{
    public Guid DialogId { get; set; }
}
