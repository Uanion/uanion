using AutoMapper;
using Uanion.Application.Features.User.Commands.CreateUser;
using Uanion.Application.Features.User.Queries.GetUser;
using Uanion.Domain.Entities;

namespace Uanion.Application.Profiles;

public class UserMappingProfile : AutoMapper.Profile
{
    public UserMappingProfile()
    {   
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, UserViewModel>();
    }
}
