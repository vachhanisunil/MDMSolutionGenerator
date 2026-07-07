using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Validators;

public sealed class CreateMaterialUOMCommandValidator : AbstractValidator<CreateMaterialUOMCommand>
{
    public CreateMaterialUOMCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.UnitOfMeasureId)
            .NotEmpty();

        RuleFor(x => x.Input.ConversionNumerator)
            .NotEmpty()
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.ConversionDenominator)
            .NotEmpty()
            .GreaterThanOrEqualTo(1m);

        RuleFor(x => x.Input.Barcode)
            .MaximumLength(50);

        RuleFor(x => x.Input.IsBaseUnit)
            .NotEmpty();

    }
}
