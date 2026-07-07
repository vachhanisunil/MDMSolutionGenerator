using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Validators;

public sealed class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyCommandValidator()
    {
        RuleFor(x => x.Input.Code)
            .NotEmpty()
            .MaximumLength(3);

        RuleFor(x => x.Input.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.DecimalPlaces)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(4);

    }
}
