using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Validators;

public sealed class BulkDeleteStorageLocationCommandValidator : AbstractValidator<BulkDeleteStorageLocationCommand>
{
    public BulkDeleteStorageLocationCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}