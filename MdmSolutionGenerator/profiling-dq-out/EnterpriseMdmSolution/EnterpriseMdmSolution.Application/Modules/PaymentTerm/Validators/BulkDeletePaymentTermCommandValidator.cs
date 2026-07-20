using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Validators;

public sealed class BulkDeletePaymentTermCommandValidator : AbstractValidator<BulkDeletePaymentTermCommand>
{
    public BulkDeletePaymentTermCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}