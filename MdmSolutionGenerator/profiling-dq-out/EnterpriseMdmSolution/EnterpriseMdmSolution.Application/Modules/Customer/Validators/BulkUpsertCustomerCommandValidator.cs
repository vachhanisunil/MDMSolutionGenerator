using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Validators;

public sealed class BulkUpsertCustomerCommandValidator : AbstractValidator<BulkUpsertCustomerCommand>
{
    public BulkUpsertCustomerCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.CustomerNumber)
                .NotEmpty()
                .MaximumLength(20);

            item.RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(200);

            item.RuleFor(x => x.CustomerType)
                .NotEmpty()
                .MaximumLength(30)
                .Must(value => new[] { "Individual", "Corporate", "Government", "Distributor" }.Contains(value)).WithMessage("CustomerType contains an unsupported value");

            item.RuleFor(x => x.Email)
                .MaximumLength(250)
                .EmailAddress();

            item.RuleFor(x => x.Phone)
                .MaximumLength(30);

            item.RuleFor(x => x.CountryId)
                .NotEmpty();

            item.RuleFor(x => x.CurrencyId)
                .NotEmpty();

            item.RuleFor(x => x.IndustryCode)
                .MaximumLength(30);

            item.RuleFor(x => x.RiskCategory)
                .MaximumLength(30)
                .Must(value => new[] { "Low", "Medium", "High" }.Contains(value)).WithMessage("RiskCategory contains an unsupported value");

            item.RuleFor(x => x.RegistrationNumber)
                .MaximumLength(50);

            item.RuleFor(x => x.IsActive)
                .NotEmpty();

        });
    }
}
