using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Material.Validators;

public sealed class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(x => x.Input.MaterialNumber)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(x => x.Input.MaterialName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.MaterialType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "RawMaterial", "FinishedGood", "SemiFinished", "Service" }.Contains(value)).WithMessage("MaterialType contains an unsupported value");

        RuleFor(x => x.Input.MaterialGroupId)
            .NotEmpty();

        RuleFor(x => x.Input.BaseUnitOfMeasureId)
            .NotEmpty();

        RuleFor(x => x.Input.GlobalTradeItemNumber)
            .MaximumLength(50);

        RuleFor(x => x.Input.ProductHierarchy)
            .MaximumLength(50);

        RuleFor(x => x.Input.GrossWeight)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.NetWeight)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.IsBatchManaged)
            .NotEmpty();

        RuleFor(x => x.Input.IsSerialManaged)
            .NotEmpty();

        RuleFor(x => x.Input.IsActive)
            .NotEmpty();

    }
}
