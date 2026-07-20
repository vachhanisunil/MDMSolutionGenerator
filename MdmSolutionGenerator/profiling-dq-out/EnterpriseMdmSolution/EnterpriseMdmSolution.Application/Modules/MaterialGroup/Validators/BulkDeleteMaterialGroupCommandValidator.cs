using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Validators;

public sealed class BulkDeleteMaterialGroupCommandValidator : AbstractValidator<BulkDeleteMaterialGroupCommand>
{
    public BulkDeleteMaterialGroupCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}