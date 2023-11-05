using FluentValidation;

namespace Uanion.Application.Features.Dialoge.Commands.CreateDialoge;

public class CreateDialogeCommandValidator : AbstractValidator<CreateDialogeCommand>
{
    public CreateDialogeCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.Nickname)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.FirstName)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

        RuleFor(p => p.LastName)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");
    }
}
