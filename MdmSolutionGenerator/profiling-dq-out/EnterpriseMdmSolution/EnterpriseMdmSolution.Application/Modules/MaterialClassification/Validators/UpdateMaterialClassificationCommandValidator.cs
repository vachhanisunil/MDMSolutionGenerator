using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Validators;

public sealed class UpdateMaterialClassificationCommandValidator : AbstractValidator<UpdateMaterialClassificationCommand>
{
    public UpdateMaterialClassificationCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.ClassType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.ClassValue)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.CharacteristicName)
            .MaximumLength(100);

    }
}
