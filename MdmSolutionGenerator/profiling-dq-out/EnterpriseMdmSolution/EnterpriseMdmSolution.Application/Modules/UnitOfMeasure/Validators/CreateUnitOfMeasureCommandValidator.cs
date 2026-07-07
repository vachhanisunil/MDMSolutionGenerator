using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Validators;

public sealed class CreateUnitOfMeasureCommandValidator : AbstractValidator<CreateUnitOfMeasureCommand>
{
    public CreateUnitOfMeasureCommandValidator()
    {
        RuleFor(x => x.Input.Code)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Input.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.Dimension)
            .MaximumLength(50);

    }
}
