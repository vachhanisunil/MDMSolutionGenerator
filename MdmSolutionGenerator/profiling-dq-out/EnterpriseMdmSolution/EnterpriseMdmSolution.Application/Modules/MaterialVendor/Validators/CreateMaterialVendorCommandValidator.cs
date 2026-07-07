using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Validators;

public sealed class CreateMaterialVendorCommandValidator : AbstractValidator<CreateMaterialVendorCommand>
{
    public CreateMaterialVendorCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.VendorMaterialNumber)
            .MaximumLength(50);

        RuleFor(x => x.Input.LeadTimeDays)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(365);

        RuleFor(x => x.Input.MinimumOrderQuantity)
            .GreaterThanOrEqualTo(0m);

        RuleFor(x => x.Input.IsPreferred)
            .NotEmpty();

    }
}
