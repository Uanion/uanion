using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(Domain.Entities.User), request.UserId);

        if (request.IsHardDelete)
        {
            await _userRepository.DeleteAsync(userToDelete);
        }
        else
        {
            userToDelete.IsDeleted = true;
            await _userRepository.UpdateAsync(userToDelete);
        }
    }
}
