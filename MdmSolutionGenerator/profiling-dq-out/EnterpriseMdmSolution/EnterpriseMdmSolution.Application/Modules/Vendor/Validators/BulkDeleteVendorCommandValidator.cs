using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Validators;

public sealed class BulkDeleteVendorCommandValidator : AbstractValidator<BulkDeleteVendorCommand>
{
    public BulkDeleteVendorCommandValidator()
    {
        RuleFor(x => x.Input.Ids)
            .NotEmpty();

        RuleForEach(x => x.Input.Ids)
            .NotEqual(0);
    }
}