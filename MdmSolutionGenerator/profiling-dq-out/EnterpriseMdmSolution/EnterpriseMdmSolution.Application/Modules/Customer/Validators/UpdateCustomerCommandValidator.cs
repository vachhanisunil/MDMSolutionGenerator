using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Validators;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Input.CustomerNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.CustomerName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.CustomerType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "Individual", "Corporate", "Government", "Distributor" }.Contains(value)).WithMessage("CustomerType contains an unsupported value");

        RuleFor(x => x.Input.Email)
            .MaximumLength(250)
            .EmailAddress();

        RuleFor(x => x.Input.Phone)
            .MaximumLength(30);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

        RuleFor(x => x.Input.IndustryCode)
            .MaximumLength(30);

        RuleFor(x => x.Input.RiskCategory)
            .MaximumLength(30)
            .Must(value => new[] { "Low", "Medium", "High" }.Contains(value)).WithMessage("RiskCategory contains an unsupported value");

        RuleFor(x => x.Input.RegistrationNumber)
            .MaximumLength(50);

        RuleFor(x => x.Input.IsActive)
            .NotEmpty();

    }
}
