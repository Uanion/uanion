using FluentValidation;
using Uanion.Application.Contracts.Persistence;

namespace Uanion.Application.Features.Profile.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateProfileCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(p => p.ProfileId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.UserId)
         .NotEmpty().WithMessage("{PropertyName} is required")
         .NotNull()
         .MustAsync(IsUserExist).WithMessage("User with ID {UserId} does not exist");
    }
    private async Task<bool> IsUserExist(Guid userId, CancellationToken token) =>
    await _userRepository.GetByIdAsync(userId) != null;
}
