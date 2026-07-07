using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Validators;

public sealed class UpdateCustomerPartnerFunctionCommandValidator : AbstractValidator<UpdateCustomerPartnerFunctionCommand>
{
    public UpdateCustomerPartnerFunctionCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.PartnerFunctionCode)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Input.Description)
            .MaximumLength(200);

        RuleFor(x => x.Input.IsDefault)
            .NotEmpty();

    }
}
