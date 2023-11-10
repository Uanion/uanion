using Uanion.Application.Features.User.Commands.CreateUser;
using Uanion.Application.Features.User.Commands.UpdateUser;
using Uanion.Application.Features.User.Queries.GetUser;
using Uanion.Application.Features.User.Queries.GetUsersList;
using Uanion.Domain.Entities;

namespace Uanion.Application.MappingProfiles;

public class UserMappingProfile : AutoMapper.Profile
{
    public UserMappingProfile()
    {   
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();

        CreateMap<User, UserViewModel>();
        CreateMap<User, UserListViewModel>();
    }
}
