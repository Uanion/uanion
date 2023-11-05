using MediatR;

namespace Uanion.Application.Features.Profile.Queries.GetProfile;

public class GetProfileQuery : IRequest<ProfileViewModel>
{
    public Guid ProfileId { get; set; }
}