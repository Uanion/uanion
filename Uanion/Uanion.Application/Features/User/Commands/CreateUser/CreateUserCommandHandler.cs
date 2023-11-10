using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly CreateUserCommandValidator _validator;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = new CreateUserCommandValidator();
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.Errors.Count > 0)
        {
            throw new Exceptions.ValidationException(validatorResult);
        }

        var user = _mapper.Map<Domain.Entities.User>(request);

        user = await _userRepository.AddAsync(user);

        return user.UserId;
    }
}
