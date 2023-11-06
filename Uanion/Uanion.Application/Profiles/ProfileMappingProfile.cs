using AutoMapper;
using Uanion.Application.Features.Profile.Commands.CreateProfile;
using Uanion.Application.Features.Profile.Queries.GetProfile;
using Uanion.Domain.Entities;

namespace Uanion.Application.Profiles;

public class ProfileMappingProfile : Profile
{
    public ProfileMappingProfile()
    {
        CreateMap<CreateProfileCommand, Profile>();
        CreateMap<Profile, ProfileViewModel>();
    }
}
