using FluentValidation;

namespace Uanion.Application.Features.Dialog.Commands.UpdateDialog;

public class UpdateDialogCommandValidator : AbstractValidator<UpdateDialogCommand>
{
    public UpdateDialogCommandValidator()
    {
        RuleFor(p => p.DialogId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
    }
}
