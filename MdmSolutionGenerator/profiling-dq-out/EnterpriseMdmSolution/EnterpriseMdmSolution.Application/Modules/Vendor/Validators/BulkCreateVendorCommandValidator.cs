using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Validators;

public sealed class BulkCreateVendorCommandValidator : AbstractValidator<BulkCreateVendorCommand>
{
    public BulkCreateVendorCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.VendorNumber)
                .NotEmpty()
                .MaximumLength(20);

            item.RuleFor(x => x.VendorName)
                .NotEmpty()
                .MaximumLength(200);

            item.RuleFor(x => x.VendorType)
                .NotEmpty()
                .MaximumLength(30)
                .Must(value => new[] { "Manufacturer", "Distributor", "ServiceProvider", "Contractor" }.Contains(value)).WithMessage("VendorType contains an unsupported value");

            item.RuleFor(x => x.Email)
                .MaximumLength(250)
                .EmailAddress();

            item.RuleFor(x => x.Phone)
                .MaximumLength(30);

            item.RuleFor(x => x.CountryId)
                .NotEmpty();

            item.RuleFor(x => x.CurrencyId)
                .NotEmpty();

            item.RuleFor(x => x.SupplierCategory)
                .MaximumLength(50);

            item.RuleFor(x => x.DunsNumber)
                .MaximumLength(30);

            item.RuleFor(x => x.OnboardingStatus)
                .MaximumLength(30)
                .Must(value => new[] { "Draft", "UnderReview", "Approved", "Rejected", "Blocked" }.Contains(value)).WithMessage("OnboardingStatus contains an unsupported value");

            item.RuleFor(x => x.IsActive)
                .NotEmpty();

        });
    }
}
