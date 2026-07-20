using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Plant.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Validators;

public sealed class BulkCreatePlantCommandValidator : AbstractValidator<BulkCreatePlantCommand>
{
    public BulkCreatePlantCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.PlantCode)
                .NotEmpty()
                .MaximumLength(10);

            item.RuleFor(x => x.PlantName)
                .NotEmpty()
                .MaximumLength(150);

            item.RuleFor(x => x.CountryId)
                .NotEmpty();

        });
    }
}
