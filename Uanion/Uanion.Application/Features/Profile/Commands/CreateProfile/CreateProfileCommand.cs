using MediatR;

namespace Uanion.Application.Features.Profile.Commands.CreateProfile;

public class CreateProfileCommand : IRequest<Guid>
{
	public Guid UserId { get; set; }
}
