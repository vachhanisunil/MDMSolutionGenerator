using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Validators;

public sealed class UpdateMaterialPlantCommandValidator : AbstractValidator<UpdateMaterialPlantCommand>
{
    public UpdateMaterialPlantCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.PlantId)
            .NotEmpty();

        RuleFor(x => x.Input.ProcurementType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "InHouse", "External", "Both" }.Contains(value)).WithMessage("ProcurementType contains an unsupported value");

        RuleFor(x => x.Input.ReorderPoint)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.MinimumLotSize)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.MaximumLotSize)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.MrpType)
            .MaximumLength(20);

        RuleFor(x => x.Input.PlanningTimeFenceDays)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(365);

        RuleFor(x => x.Input.ProfitCenter)
            .MaximumLength(50);

    }
}
