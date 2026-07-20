using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Validators;

public sealed class BulkDeleteUnitOfMeasureCommandValidator : AbstractValidator<BulkDeleteUnitOfMeasureCommand>
{
    public BulkDeleteUnitOfMeasureCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}