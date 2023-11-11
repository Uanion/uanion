using Uanion.Application.Features.Profile.Commands.CreateProfile;
using Uanion.Application.Features.Profile.Commands.UpdateProfile;
using Uanion.Application.Features.Profile.Queries.GetProfile;
using Uanion.Application.Features.Profile.Queries.GetProfilesList;
using Uanion.Domain.Entities;

namespace Uanion.Application.MappingProfiles;

public class ProfileMappingProfile : AutoMapper.Profile
{
    public ProfileMappingProfile()
    {
        CreateMap<CreateProfileCommand, Domain.Entities.Profile>();
        CreateMap<UpdateProfileCommand, Profile>();

        CreateMap<Domain.Entities.Profile, ProfileViewModel>();
        CreateMap<Domain.Entities.Profile, ProfileListViewModel>();
    }
}
