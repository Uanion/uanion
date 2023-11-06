using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Profile.Queries.GetProfile;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileViewModel>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public GetProfileQueryHandler(IProfileRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<ProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.GetByIdAsync(request.ProfileId);
        var profileVm = _mapper.Map<ProfileViewModel>(profile);

        return profileVm;
    }
}
