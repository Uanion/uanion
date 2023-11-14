using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.Dialog.Commands.DeleteDialog;

public class DeleteDialogCommandHandler : IRequestHandler<DeleteDialogCommand>
{
    private readonly IDialogRepository _dialogRepository;

    public DeleteDialogCommandHandler(IDialogRepository dialogRepository)
    {
        _dialogRepository = dialogRepository;
    }

    public async Task Handle(DeleteDialogCommand request, CancellationToken cancellationToken)
    {
        var dialogToDelete = await _dialogRepository.GetByIdAsync(request.DialogId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Dialog), request.DialogId);

        if (request.IsHardDelete)
        {
            await _dialogRepository.DeleteAsync(dialogToDelete);
        }
        else
        {
            dialogToDelete.IsDeleted = true;
            await _dialogRepository.UpdateAsync(dialogToDelete);
        }
    }
}
