using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Validators;

public sealed class BulkDeletePlantCommandValidator : AbstractValidator<BulkDeletePlantCommand>
{
    public BulkDeletePlantCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}