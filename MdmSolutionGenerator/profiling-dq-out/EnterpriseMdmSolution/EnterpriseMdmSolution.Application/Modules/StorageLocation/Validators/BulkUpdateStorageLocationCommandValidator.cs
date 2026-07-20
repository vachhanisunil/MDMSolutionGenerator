using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Validators;

public sealed class BulkUpdateStorageLocationCommandValidator : AbstractValidator<BulkUpdateStorageLocationCommand>
{
    public BulkUpdateStorageLocationCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Id)
                .NotEqual(0);

            item.RuleFor(x => x.StorageLocationCode)
                .NotEmpty()
                .MaximumLength(10);

            item.RuleFor(x => x.StorageLocationName)
                .NotEmpty()
                .MaximumLength(150);

            item.RuleFor(x => x.PlantId)
                .NotEmpty();

        });
    }
}
