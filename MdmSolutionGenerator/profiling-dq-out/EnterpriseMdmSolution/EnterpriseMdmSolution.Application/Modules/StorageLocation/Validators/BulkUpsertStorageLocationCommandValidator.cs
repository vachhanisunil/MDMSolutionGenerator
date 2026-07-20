using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Validators;

public sealed class BulkUpsertStorageLocationCommandValidator : AbstractValidator<BulkUpsertStorageLocationCommand>
{
    public BulkUpsertStorageLocationCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
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
