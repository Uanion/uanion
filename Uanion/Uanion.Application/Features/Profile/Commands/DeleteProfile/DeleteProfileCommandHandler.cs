using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.Profile.Commands.DeleteProfile;

public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public DeleteProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profileToDelete = await _profileRepository.GetByIdAsync(request.ProfileId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Profile), request.ProfileId);

        if (request.IsHardDelete)
        {
            await _profileRepository.DeleteAsync(profileToDelete);
        }
        else
        {
            profileToDelete.IsDeleted = true;
            await _profileRepository.UpdateAsync(profileToDelete);
        }
    }
}
