using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Material.Validators;

public sealed class BulkUpsertMaterialCommandValidator : AbstractValidator<BulkUpsertMaterialCommand>
{
    public BulkUpsertMaterialCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.MaterialNumber)
                .NotEmpty()
                .MaximumLength(40);

            item.RuleFor(x => x.MaterialName)
                .NotEmpty()
                .MaximumLength(200);

            item.RuleFor(x => x.MaterialType)
                .NotEmpty()
                .MaximumLength(30)
                .Must(value => new[] { "RawMaterial", "FinishedGood", "SemiFinished", "Service" }.Contains(value)).WithMessage("MaterialType contains an unsupported value");

            item.RuleFor(x => x.MaterialGroupId)
                .NotEmpty();

            item.RuleFor(x => x.BaseUnitOfMeasureId)
                .NotEmpty();

            item.RuleFor(x => x.GlobalTradeItemNumber)
                .MaximumLength(50);

            item.RuleFor(x => x.ProductHierarchy)
                .MaximumLength(50);

            item.RuleFor(x => x.GrossWeight)
                .GreaterThanOrEqualTo(0m);

            item.RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0m);

            item.RuleFor(x => x.IsBatchManaged)
                .NotEmpty();

            item.RuleFor(x => x.IsSerialManaged)
                .NotEmpty();

            item.RuleFor(x => x.IsActive)
                .NotEmpty();

        });
    }
}
