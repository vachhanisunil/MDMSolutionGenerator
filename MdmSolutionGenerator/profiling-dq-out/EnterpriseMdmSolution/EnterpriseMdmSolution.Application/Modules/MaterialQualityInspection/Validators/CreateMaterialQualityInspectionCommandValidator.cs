using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Validators;

public sealed class CreateMaterialQualityInspectionCommandValidator : AbstractValidator<CreateMaterialQualityInspectionCommand>
{
    public CreateMaterialQualityInspectionCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.InspectionType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.InspectionIntervalDays)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(3650);

        RuleFor(x => x.Input.QualityCertificateRequired)
            .NotEmpty();

        RuleFor(x => x.Input.SampleSize)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.AcceptanceCriteria)
            .MaximumLength(500);

    }
}
