using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Validators;

public sealed class BulkUpdateSalesOrganizationCommandValidator : AbstractValidator<BulkUpdateSalesOrganizationCommand>
{
    public BulkUpdateSalesOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Id)
                .NotEqual(0);

            item.RuleFor(x => x.SalesOrganizationCode)
                .NotEmpty()
                .MaximumLength(10);

            item.RuleFor(x => x.SalesOrganizationName)
                .NotEmpty()
                .MaximumLength(150);

            item.RuleFor(x => x.CurrencyId)
                .NotEmpty();

        });
    }
}
