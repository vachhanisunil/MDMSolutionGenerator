using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Validators;

public sealed class UpdateVendorContactCommandValidator : AbstractValidator<UpdateVendorContactCommand>
{
    public UpdateVendorContactCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
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

        RuleFor(x => x.Input.IsPrimary)
            .NotEmpty();

    }
}
