using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Validators;

public sealed class UpdateSalesOrganizationCommandValidator : AbstractValidator<UpdateSalesOrganizationCommand>
{
    public UpdateSalesOrganizationCommandValidator()
    {
        RuleFor(x => x.Input.SalesOrganizationCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Input.SalesOrganizationName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

    }
}
