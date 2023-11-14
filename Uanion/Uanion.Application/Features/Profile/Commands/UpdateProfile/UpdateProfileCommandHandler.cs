using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;
using Uanion.Application.Exceptions;

namespace Uanion.Application.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;
    private readonly UpdateProfileCommandValidator _validator;

    public UpdateProfileCommandHandler(IProfileRepository profileRepository, IUserRepository userRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _validator = new UpdateProfileCommandValidator(userRepository);
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new ValidationException(validationResult);
        }

        var profileToUpdate = await _profileRepository.GetByIdAsync(request.ProfileId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Profile), request.ProfileId);

        _mapper.Map(request, profileToUpdate);
        await _profileRepository.UpdateAsync(profileToUpdate);
    }
}
