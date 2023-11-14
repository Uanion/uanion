using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Profile.Queries.GetProfilesList;

public class GetProfilesListQueryHandler : IRequestHandler<GetProfilesListQuery, List<ProfileListViewModel>>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public GetProfilesListQueryHandler(IProfileRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task<List<ProfileListViewModel>> Handle(GetProfilesListQuery request, CancellationToken cancellationToken)
    {
        var allProfiles = await _profileRepository.ListAllAsync();

        return _mapper.Map<List<ProfileListViewModel>>(allProfiles);
    }
}
