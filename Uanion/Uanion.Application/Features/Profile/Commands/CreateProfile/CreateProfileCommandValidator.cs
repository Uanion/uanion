using FluentValidation;

namespace Uanion.Application.Features.Profile.Commands.CreateProfile;

public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
{
    public CreateProfileCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotNull();
        //todo: check that this is the ID of an existing User
    }
}
