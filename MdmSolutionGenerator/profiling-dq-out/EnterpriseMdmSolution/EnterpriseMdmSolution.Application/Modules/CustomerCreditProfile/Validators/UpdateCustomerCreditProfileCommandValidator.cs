using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Validators;

public sealed class UpdateCustomerCreditProfileCommandValidator : AbstractValidator<UpdateCustomerCreditProfileCommand>
{
    public UpdateCustomerCreditProfileCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.CreditControlArea)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.CreditLimit)
            .NotEmpty()
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.CreditExposure)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.CreditRiskClass)
            .MaximumLength(30)
            .Must(value => new[] { "A", "B", "C", "D" }.Contains(value)).WithMessage("CreditRiskClass contains an unsupported value");

        RuleFor(x => x.Input.IsBlocked)
            .NotEmpty();

    }
}
