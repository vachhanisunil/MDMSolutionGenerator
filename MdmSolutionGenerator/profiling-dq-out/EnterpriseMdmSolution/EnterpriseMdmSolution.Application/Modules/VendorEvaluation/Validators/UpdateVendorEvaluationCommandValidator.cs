using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Validators;

public sealed class UpdateVendorEvaluationCommandValidator : AbstractValidator<UpdateVendorEvaluationCommand>
{
    public UpdateVendorEvaluationCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.EvaluationPeriod)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.QualityScore)
            .GreaterThanOrEqualTo(0m)
            .LessThanOrEqualTo(100m);

        RuleFor(x => x.Input.DeliveryScore)
            .GreaterThanOrEqualTo(0m)
            .LessThanOrEqualTo(100m);

        RuleFor(x => x.Input.CostScore)
            .GreaterThanOrEqualTo(0m)
            .LessThanOrEqualTo(100m);

        RuleFor(x => x.Input.OverallScore)
            .GreaterThanOrEqualTo(0m)
            .LessThanOrEqualTo(100m);

        RuleFor(x => x.Input.EvaluationDate)
            .NotEmpty();

    }
}
