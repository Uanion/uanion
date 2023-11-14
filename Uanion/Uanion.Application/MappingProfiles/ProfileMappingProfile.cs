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
        CreateMap<CreateProfileCommand, Profile>();
        CreateMap<UpdateProfileCommand, Profile>();

        CreateMap<Profile, ProfileViewModel>();
        CreateMap<Profile, ProfileListViewModel>();
    }
}
