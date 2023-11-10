using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.User.Queries.GetUsersList;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserListViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserListViewModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userRepository.ListAllAsync();
        
        return _mapper.Map<List<UserListViewModel>>(allUsers);
    }
}
