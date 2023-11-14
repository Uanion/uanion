using MediatR;

namespace Uanion.Application.Features.Dialog.Commands.DeleteDialog;

public class DeleteDialogCommand : IRequest
{
    public Guid DialogId { get; set; }

    public bool IsHardDelete { get; set; } = false;
}
