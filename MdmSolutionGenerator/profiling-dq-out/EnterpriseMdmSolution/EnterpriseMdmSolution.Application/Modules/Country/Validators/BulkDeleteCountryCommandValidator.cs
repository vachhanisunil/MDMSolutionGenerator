using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Country.Validators;

public sealed class BulkDeleteCountryCommandValidator : AbstractValidator<BulkDeleteCountryCommand>
{
    public BulkDeleteCountryCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}