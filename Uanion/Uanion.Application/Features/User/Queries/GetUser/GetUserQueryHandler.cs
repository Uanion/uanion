using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.User.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        var userVm = _mapper.Map<UserViewModel>(user);

        return userVm;
    }
}
