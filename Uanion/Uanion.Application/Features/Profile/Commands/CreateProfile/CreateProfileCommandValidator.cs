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
        .NotNull()
        .MustAsync(IsUserExist).WithMessage("User with ID {UserId} does not exist");
    }

    private async Task<bool> IsUserExist(Guid userId, CancellationToken token)
    {
        return await _userRepository.GetByIdAsync(userId) != null;
    }
}
