using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Validators;

public sealed class UpdateCustomerAddressCommandValidator : AbstractValidator<UpdateCustomerAddressCommand>
{
    public UpdateCustomerAddressCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.AddressType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "Billing", "Shipping", "Registered" }.Contains(value)).WithMessage("AddressType contains an unsupported value");

        RuleFor(x => x.Input.AddressLine1)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.AddressLine2)
            .MaximumLength(200);

        RuleFor(x => x.Input.City)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.State)
            .MaximumLength(100);

        RuleFor(x => x.Input.PostalCode)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.CountryId)
            .NotEmpty();

        RuleFor(x => x.Input.Region)
            .MaximumLength(100);

        RuleFor(x => x.Input.IsDefault)
            .NotEmpty();

    }
}
