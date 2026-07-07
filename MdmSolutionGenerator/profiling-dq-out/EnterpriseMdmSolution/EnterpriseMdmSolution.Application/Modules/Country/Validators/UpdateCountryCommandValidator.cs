using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Country.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Country.Validators;

public sealed class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(x => x.Input.Code)
            .NotEmpty()
            .MaximumLength(3);

        RuleFor(x => x.Input.Name)
            .NotEmpty()
            .MaximumLength(100);

    }
}
