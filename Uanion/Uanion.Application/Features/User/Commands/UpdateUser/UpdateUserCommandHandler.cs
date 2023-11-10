using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UpdateUserCommandValidator _validator;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = new UpdateUserCommandValidator();
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new ValidationException(validationResult);
        }

        var userToUpdate = await _userRepository.GetByIdAsync(request.UserId) 
            ?? throw new NotFoundException(nameof(Domain.Entities.User), request.UserId);

        _mapper.Map(request, userToUpdate);
        await _userRepository.UpdateAsync(userToUpdate);
    }
}
