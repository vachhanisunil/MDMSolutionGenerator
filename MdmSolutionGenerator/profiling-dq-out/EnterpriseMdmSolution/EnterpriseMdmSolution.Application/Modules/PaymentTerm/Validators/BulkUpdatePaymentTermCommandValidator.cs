using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Validators;

public sealed class BulkUpdatePaymentTermCommandValidator : AbstractValidator<BulkUpdatePaymentTermCommand>
{
    public BulkUpdatePaymentTermCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Id)
                .NotEqual(0);

            item.RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(20);

            item.RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(200);

            item.RuleFor(x => x.NetDays)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(365);

        });
    }
}
