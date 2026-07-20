using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Validators;

public sealed class BulkUpsertMaterialGroupCommandValidator : AbstractValidator<BulkUpsertMaterialGroupCommand>
{
    public BulkUpsertMaterialGroupCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(20);

            item.RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(150);

        });
    }
}
