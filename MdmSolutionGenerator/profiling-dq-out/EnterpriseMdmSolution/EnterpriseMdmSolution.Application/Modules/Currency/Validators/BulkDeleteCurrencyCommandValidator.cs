using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Currency.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Validators;

public sealed class BulkDeleteCurrencyCommandValidator : AbstractValidator<BulkDeleteCurrencyCommand>
{
    public BulkDeleteCurrencyCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}