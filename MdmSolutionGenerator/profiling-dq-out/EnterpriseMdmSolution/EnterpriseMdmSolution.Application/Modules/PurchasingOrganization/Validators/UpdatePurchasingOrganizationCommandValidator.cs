using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Validators;

public sealed class UpdatePurchasingOrganizationCommandValidator : AbstractValidator<UpdatePurchasingOrganizationCommand>
{
    public UpdatePurchasingOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.PurchasingOrganizationCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Input.PurchasingOrganizationName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

    }
}
