using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Validators;

public sealed class UpdateCustomerContactCommandValidator : AbstractValidator<UpdateCustomerContactCommand>
{
    public UpdateCustomerContactCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.Email)
            .MaximumLength(250)
            .EmailAddress();

        RuleFor(x => x.Input.Phone)
            .MaximumLength(30);

        RuleFor(x => x.Input.MobilePhone)
            .MaximumLength(30);

        RuleFor(x => x.Input.Designation)
            .MaximumLength(100);

        RuleFor(x => x.Input.Department)
            .MaximumLength(100);

        RuleFor(x => x.Input.PreferredLanguage)
            .MaximumLength(20);

        RuleFor(x => x.Input.IsPrimary)
            .NotEmpty();

    }
}
