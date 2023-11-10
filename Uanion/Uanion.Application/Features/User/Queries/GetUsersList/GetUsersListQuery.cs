using MediatR;

namespace Uanion.Application.Features.User.Queries.GetUsersList;

public class GetUsersListQuery : IRequest<List<UserListViewModel>>
{
}
