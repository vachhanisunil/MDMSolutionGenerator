using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Validators;

public sealed class UpdateMaterialGroupCommandValidator : AbstractValidator<UpdateMaterialGroupCommand>
{
    public UpdateMaterialGroupCommandValidator()
    {
        RuleFor(x => x.Input.Code)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.Name)
            .NotEmpty()
            .MaximumLength(150);

    }
}
