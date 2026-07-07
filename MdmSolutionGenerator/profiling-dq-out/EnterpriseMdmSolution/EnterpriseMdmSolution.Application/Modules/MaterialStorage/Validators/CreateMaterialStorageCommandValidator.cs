using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Validators;

public sealed class CreateMaterialStorageCommandValidator : AbstractValidator<CreateMaterialStorageCommand>
{
    public CreateMaterialStorageCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.StorageLocationId)
            .NotEmpty();

        RuleFor(x => x.Input.BinLocation)
            .MaximumLength(50);

        RuleFor(x => x.Input.SafetyStock)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.MaximumStock)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.TemperatureZone)
            .MaximumLength(30);

    }
}
