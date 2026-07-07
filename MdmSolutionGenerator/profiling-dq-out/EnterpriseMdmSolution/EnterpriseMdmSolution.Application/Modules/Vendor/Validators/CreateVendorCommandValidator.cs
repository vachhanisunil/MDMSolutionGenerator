using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Validators;

public sealed class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorCommandValidator()
    {
        RuleFor(x => x.Input.VendorNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.VendorName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.VendorType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "Manufacturer", "Distributor", "ServiceProvider", "Contractor" }.Contains(value)).WithMessage("VendorType contains an unsupported value");

        RuleFor(x => x.Input.Email)
            .MaximumLength(250)
            .EmailAddress();

        RuleFor(x => x.Input.Phone)
            .MaximumLength(30);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

        RuleFor(x => x.Input.SupplierCategory)
            .MaximumLength(50);

        RuleFor(x => x.Input.DunsNumber)
            .MaximumLength(30);

        RuleFor(x => x.Input.OnboardingStatus)
            .MaximumLength(30)
            .Must(value => new[] { "Draft", "UnderReview", "Approved", "Rejected", "Blocked" }.Contains(value)).WithMessage("OnboardingStatus contains an unsupported value");

        RuleFor(x => x.Input.IsActive)
            .NotEmpty();

    }
}
