using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Dialog.Commands.CreateDialog;

public class CreateDialogCommandHandler : IRequestHandler<CreateDialogCommand, Guid>
{
    private readonly IDialogRepository _dialogRepository;
    private readonly IMapper _mapper;
    private readonly CreateDialogCommandValidator _validator;

    public CreateDialogCommandHandler(IDialogRepository dialogRepository, IMapper mapper)
    {
        _dialogRepository = dialogRepository;
        _mapper = mapper;
        _validator = new CreateDialogCommandValidator();
    }

    public async Task<Guid> Handle(CreateDialogCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request);

        if (validatorResult.Errors.Count > 0)
        {
            throw new Exceptions.ValidationException(validatorResult);
        }

        var dialog = _mapper.Map<Domain.Entities.Dialog>(request);

        dialog = await _dialogRepository.AddAsync(dialog);

        return dialog.DialogId;
    }
}
