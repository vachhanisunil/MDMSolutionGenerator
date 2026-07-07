using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Validators;

public sealed class UpdatePlantCommandValidator : AbstractValidator<UpdatePlantCommand>
{
    public UpdatePlantCommandValidator()
    {
        RuleFor(x => x.Input.PlantCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Input.PlantName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

    }
}
