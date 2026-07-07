using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Validators;

public sealed class CreateCustomerClassificationCommandValidator : AbstractValidator<CreateCustomerClassificationCommand>
{
    public CreateCustomerClassificationCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.ClassificationType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.ClassificationValue)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.ClassificationGroup)
            .MaximumLength(50);

    }
}
