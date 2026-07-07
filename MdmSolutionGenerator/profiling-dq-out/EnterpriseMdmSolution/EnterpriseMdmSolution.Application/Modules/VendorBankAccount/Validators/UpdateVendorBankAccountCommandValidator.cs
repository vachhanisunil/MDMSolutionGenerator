using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Validators;

public sealed class UpdateVendorBankAccountCommandValidator : AbstractValidator<UpdateVendorBankAccountCommand>
{
    public UpdateVendorBankAccountCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
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
