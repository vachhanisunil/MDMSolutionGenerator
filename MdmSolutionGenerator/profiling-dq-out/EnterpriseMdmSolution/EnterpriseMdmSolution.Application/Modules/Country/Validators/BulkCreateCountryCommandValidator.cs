using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Country.Validators;

public sealed class BulkCreateCountryCommandValidator : AbstractValidator<BulkCreateCountryCommand>
{
    public BulkCreateCountryCommandValidator()
    {
        RuleFor(x => x.Input.Items)
            .NotEmpty();

        RuleForEach(x => x.Input.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(3);

            item.RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

        });
    }
}
