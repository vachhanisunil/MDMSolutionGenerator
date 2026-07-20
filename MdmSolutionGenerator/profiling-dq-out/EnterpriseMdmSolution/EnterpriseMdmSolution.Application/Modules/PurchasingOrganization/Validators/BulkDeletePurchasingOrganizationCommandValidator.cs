using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Validators;

public sealed class BulkDeletePurchasingOrganizationCommandValidator : AbstractValidator<BulkDeletePurchasingOrganizationCommand>
{
    public BulkDeletePurchasingOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}