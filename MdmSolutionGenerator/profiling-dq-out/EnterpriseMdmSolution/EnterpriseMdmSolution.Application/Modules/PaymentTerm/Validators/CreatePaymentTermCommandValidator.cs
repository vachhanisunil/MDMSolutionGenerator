using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Validators;

public sealed class CreatePaymentTermCommandValidator : AbstractValidator<CreatePaymentTermCommand>
{
    public CreatePaymentTermCommandValidator()
    {
        RuleFor(x => x.Input.Code)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.Description)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.NetDays)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(365);

    }
}
