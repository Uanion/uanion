using AutoMapper;
using MediatR;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Profile.Commands.CreateProfile;

public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;
    private readonly CreateProfileCommandValidator _validator;

    public CreateProfileCommandHandler(IProfileRepository profileRepository, IUserRepository userRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _validator = new CreateProfileCommandValidator(userRepository);
    }

    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.Errors.Count > 0)
        {
            throw new Exceptions.ValidationException(validatorResult);
        }

        var profile = _mapper.Map<Domain.Entities.Profile>(request);

        profile = await _profileRepository.AddAsync(profile);

        return profile.ProfileId;
    }
}
