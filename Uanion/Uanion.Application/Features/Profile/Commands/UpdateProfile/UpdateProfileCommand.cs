using MediatR;

namespace Uanion.Application.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommand : IRequest
{
    public Guid ProfileId { get; set; }
    public Guid UserId { get; set; }
}
