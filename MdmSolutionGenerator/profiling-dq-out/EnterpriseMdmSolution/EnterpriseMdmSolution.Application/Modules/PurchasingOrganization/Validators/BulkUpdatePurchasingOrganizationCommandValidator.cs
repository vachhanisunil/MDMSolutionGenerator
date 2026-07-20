using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Validators;

public sealed class BulkUpdatePurchasingOrganizationCommandValidator : AbstractValidator<BulkUpdatePurchasingOrganizationCommand>
{
    public BulkUpdatePurchasingOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Id)
                .NotEqual(0);

            item.RuleFor(x => x.PurchasingOrganizationCode)
                .NotEmpty()
                .MaximumLength(10);

            item.RuleFor(x => x.PurchasingOrganizationName)
                .NotEmpty()
                .MaximumLength(150);

            item.RuleFor(x => x.CurrencyId)
                .NotEmpty();

        });
    }
}
