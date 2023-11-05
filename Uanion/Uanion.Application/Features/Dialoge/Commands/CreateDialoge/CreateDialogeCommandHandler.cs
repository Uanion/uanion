using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Dialoge.Commands.CreateDialoge;

public class CreateDialogeCommandHandler : IRequestHandler<CreateDialogeCommand, Guid>
{
    private readonly IDialogeRepository _dialogeRepository;
    private readonly IMapper _mapper;
    private readonly CreateDialogeCommandValidator _validator;

    public CreateDialogeCommandHandler(IDialogeRepository dialogeRepository, IMapper mapper)
    {
        _dialogeRepository = dialogeRepository;
        _mapper = mapper;
        _validator = new CreateDialogeCommandValidator();
    }

    public async Task<Guid> Handle(CreateDialogeCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request);

        if (validatorResult.Errors.Count > 0)
        {
            throw new Exceptions.ValidationException(validatorResult);
        }

        var dialoge = _mapper.Map<Domain.Entities.Dialoge>(request);

        dialoge = await _dialogeRepository.AddAsync(dialoge);

        return dialoge.DialogeId;
    }
}
