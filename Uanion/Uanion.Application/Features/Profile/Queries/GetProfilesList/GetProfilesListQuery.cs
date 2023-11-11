using MediatR;

namespace Uanion.Application.Features.Profile.Queries.GetProfilesList;

public class GetProfilesListQuery : IRequest<List<ProfileListViewModel>>
{
}
