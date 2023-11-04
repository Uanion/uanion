using MediatR;

namespace Uanion.Application.Features.User.Queries.GetUser;

public class GetUserQuery : IRequest<UserViewModel>
{
    public Guid UserId { get; set; }
}
