using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Validators;

public sealed class BulkCreateSalesOrganizationCommandValidator : AbstractValidator<BulkCreateSalesOrganizationCommand>
{
    public BulkCreateSalesOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
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
