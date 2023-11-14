using MediatR;

namespace Uanion.Application.Features.Profile.Commands.DeleteProfile;

public class DeleteProfileCommand : IRequest
{
    public Guid ProfileId { get; set; }

    public bool IsHardDelete { get; set; } = false;
}
