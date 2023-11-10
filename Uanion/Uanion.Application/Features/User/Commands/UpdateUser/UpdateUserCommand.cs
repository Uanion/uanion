using MediatR;

namespace Uanion.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid UserId { get; set; }

    public string Nickname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool EmailVerified { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
