using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Validators;

public sealed class UpdateMaterialForecastCommandValidator : AbstractValidator<UpdateMaterialForecastCommand>
{
    public UpdateMaterialForecastCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.PlantId)
            .NotEmpty();

        RuleFor(x => x.Input.ForecastPeriod)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.ForecastQuantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.ForecastUnitOfMeasureId)
            .NotEmpty();

        RuleFor(x => x.Input.ConfidencePercent)
            .GreaterThanOrEqualTo(0m)
            .LessThanOrEqualTo(100m);

    }
}
