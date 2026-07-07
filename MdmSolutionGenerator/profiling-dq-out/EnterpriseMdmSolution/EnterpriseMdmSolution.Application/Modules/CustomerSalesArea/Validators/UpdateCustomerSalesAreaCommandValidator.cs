using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Validators;

public sealed class UpdateCustomerSalesAreaCommandValidator : AbstractValidator<UpdateCustomerSalesAreaCommand>
{
    public UpdateCustomerSalesAreaCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.SalesOrganizationId)
            .NotEmpty();

        RuleFor(x => x.Input.DistributionChannel)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Input.Division)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Input.CreditLimit)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.CustomerGroup)
            .MaximumLength(50);

        RuleFor(x => x.Input.SalesOffice)
            .MaximumLength(50);

        RuleFor(x => x.Input.SalesDistrict)
            .MaximumLength(50);

    }
}
