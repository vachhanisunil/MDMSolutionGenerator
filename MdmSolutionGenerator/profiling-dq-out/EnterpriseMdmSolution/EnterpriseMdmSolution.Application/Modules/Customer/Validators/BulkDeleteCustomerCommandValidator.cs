using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Validators;

public sealed class BulkDeleteCustomerCommandValidator : AbstractValidator<BulkDeleteCustomerCommand>
{
    public BulkDeleteCustomerCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}