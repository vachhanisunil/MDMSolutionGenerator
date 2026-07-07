using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Validators;

public sealed class UpdateCustomerBankAccountCommandValidator : AbstractValidator<UpdateCustomerBankAccountCommand>
{
    public UpdateCustomerBankAccountCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.BankName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.AccountNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.IfscCode)
            .MaximumLength(20);

        RuleFor(x => x.Input.SwiftCode)
            .MaximumLength(20);

        RuleFor(x => x.Input.CurrencyId)
            .NotEmpty();

        RuleFor(x => x.Input.AccountHolderName)
            .MaximumLength(150);

        RuleFor(x => x.Input.IsDefault)
            .NotEmpty();

    }
}
