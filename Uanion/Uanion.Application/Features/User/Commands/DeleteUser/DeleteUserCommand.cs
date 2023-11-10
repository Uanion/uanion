using MediatR;

namespace Uanion.Application.Features.User.Commands.DeleteUser;
public class DeleteUserCommand : IRequest
{
    public Guid UserId { get; set; }

    public bool IsHardDelete { get; set; } = false;
}
