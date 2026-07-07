using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Validators;

public sealed class CreateVendorComplianceCommandValidator : AbstractValidator<CreateVendorComplianceCommand>
{
    public CreateVendorComplianceCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.ComplianceType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.ComplianceStatus)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "Pending", "Approved", "Rejected", "Expired" }.Contains(value)).WithMessage("ComplianceStatus contains an unsupported value");

        RuleFor(x => x.Input.CertificateNumber)
            .MaximumLength(100);

        RuleFor(x => x.Input.ReviewOwner)
            .MaximumLength(100);

    }
}
