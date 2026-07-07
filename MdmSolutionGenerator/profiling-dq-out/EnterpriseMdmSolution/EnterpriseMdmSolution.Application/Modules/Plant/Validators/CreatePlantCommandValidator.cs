using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Validators;

public sealed class CreatePlantCommandValidator : AbstractValidator<CreatePlantCommand>
{
    public CreatePlantCommandValidator()
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
