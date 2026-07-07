using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Validators;

public sealed class CreateCustomerTaxCommandValidator : AbstractValidator<CreateCustomerTaxCommand>
{
    public CreateCustomerTaxCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.TaxType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.TaxNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

        RuleFor(x => x.Input.IsExempt)
            .NotEmpty();

    }
}
