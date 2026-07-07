using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Validators;

public sealed class CreateMaterialPriceCommandValidator : AbstractValidator<CreateMaterialPriceCommand>
{
    public CreateMaterialPriceCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

        RuleFor(x => x.Input.PriceType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "Standard", "MovingAverage", "Sales", "Purchase" }.Contains(value)).WithMessage("PriceType contains an unsupported value");

        RuleFor(x => x.Input.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.PriceUnit)
            .NotEmpty()
            .GreaterThanOrEqualTo(1m);

        RuleFor(x => x.Input.ValidFrom)
            .NotEmpty();

        RuleFor(x => x.Input.SourceSystem)
            .MaximumLength(50);

    }
}
