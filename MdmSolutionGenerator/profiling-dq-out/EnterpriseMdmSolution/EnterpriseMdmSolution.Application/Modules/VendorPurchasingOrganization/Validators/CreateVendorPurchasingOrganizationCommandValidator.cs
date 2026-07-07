using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Validators;

public sealed class CreateVendorPurchasingOrganizationCommandValidator : AbstractValidator<CreateVendorPurchasingOrganizationCommand>
{
    public CreateVendorPurchasingOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.PurchasingOrganizationId)
            .NotEmpty();

        RuleFor(x => x.Input.Incoterms)
            .MaximumLength(30);

        RuleFor(x => x.Input.PurchaseGroup)
            .MaximumLength(50);

        RuleFor(x => x.Input.MinimumOrderValue)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.IsBlockedForPurchasing)
            .NotEmpty();

    }
}
