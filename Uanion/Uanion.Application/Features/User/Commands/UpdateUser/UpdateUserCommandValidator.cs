using FluentValidation;

namespace Uanion.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.Password)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.Nickname)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.FirstName)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.LastName)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");
    }
}
