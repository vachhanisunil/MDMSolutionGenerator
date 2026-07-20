using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Validators;

public sealed class BulkDeleteSalesOrganizationCommandValidator : AbstractValidator<BulkDeleteSalesOrganizationCommand>
{
    public BulkDeleteSalesOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}