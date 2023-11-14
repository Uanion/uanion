using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.Dialog.Commands.UpdateDialog;

public class UpdateDialogCommandHandler : IRequestHandler<UpdateDialogCommand>
{
    private readonly IDialogRepository _dialogRepository;
    private readonly IMapper _mapper;
    private readonly UpdateDialogCommandValidator _validator;

    public UpdateDialogCommandHandler(IDialogRepository dialogRepository, IMapper mapper)
    {
        _dialogRepository = dialogRepository;
        _mapper = mapper;
        _validator = new UpdateDialogCommandValidator();
    }

    public async Task Handle(UpdateDialogCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new ValidationException(validationResult);
        }

        var dialogToUpdate = await _dialogRepository.GetByIdAsync(request.DialogId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Dialog), request.DialogId);

        _mapper.Map(request, dialogToUpdate);
        await _dialogRepository.UpdateAsync(dialogToUpdate);
    }
}
