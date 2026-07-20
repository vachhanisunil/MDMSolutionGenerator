using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Validators;

public sealed class BulkCreateCurrencyCommandValidator : AbstractValidator<BulkCreateCurrencyCommand>
{
    public BulkCreateCurrencyCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(3);

            item.RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            item.RuleFor(x => x.DecimalPlaces)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(4);

        });
    }
}
