using Uanion.Application.Features.Profile.Commands.CreateProfile;
using Uanion.Application.Features.Profile.Queries.GetProfile;

namespace Uanion.Application.MappingProfiles;

public class ProfileMappingProfile : AutoMapper.Profile
{
    public ProfileMappingProfile()
    {
        CreateMap<CreateProfileCommand, Domain.Entities.Profile>();
        CreateMap<Domain.Entities.Profile, ProfileViewModel>();
    }
}
