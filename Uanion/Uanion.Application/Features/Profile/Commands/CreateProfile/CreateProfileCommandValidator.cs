using FluentValidation;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Profile.Commands.CreateProfile;

public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateProfileCommandValidator(IUserRepository userRepository)
    {   
        _userRepository = userRepository;

        RuleFor(p => p.UserId)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull()
        .MustAsync(IsUserExist).WithMessage("User with ID {PropertyValue} does not exist");
    }

    private async Task<bool> IsUserExist(Guid userId, CancellationToken token) =>
        await _userRepository.GetByIdAsync(userId) != null;
}
