using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Validators;

public sealed class BulkUpdateUnitOfMeasureCommandValidator : AbstractValidator<BulkUpdateUnitOfMeasureCommand>
{
    public BulkUpdateUnitOfMeasureCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Id)
                .NotEqual(0);

            item.RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(10);

            item.RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            item.RuleFor(x => x.Dimension)
                .MaximumLength(50);

        });
    }
}
