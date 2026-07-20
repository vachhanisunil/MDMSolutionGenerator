using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Material.Validators;

public sealed class BulkDeleteMaterialCommandValidator : AbstractValidator<BulkDeleteMaterialCommand>
{
    public BulkDeleteMaterialCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}