using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Validators;

public sealed class UpdateVendorTaxCommandValidator : AbstractValidator<UpdateVendorTaxCommand>
{
    public UpdateVendorTaxCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.TaxType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.TaxNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

    }
}
