using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Validators;

public sealed class UpdateStorageLocationCommandValidator : AbstractValidator<UpdateStorageLocationCommand>
{
    public UpdateStorageLocationCommandValidator()
    {
        RuleFor(x => x.Input.StorageLocationCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Input.StorageLocationName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.PlantId)
            .NotEmpty();

    }
}
