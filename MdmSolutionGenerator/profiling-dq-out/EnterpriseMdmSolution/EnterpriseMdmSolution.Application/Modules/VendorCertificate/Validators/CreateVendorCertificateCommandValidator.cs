using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Validators;

public sealed class CreateVendorCertificateCommandValidator : AbstractValidator<CreateVendorCertificateCommand>
{
    public CreateVendorCertificateCommandValidator()
    {
        RuleFor(x => x.Input.VendorId)
            .NotEmpty();

        RuleFor(x => x.Input.CertificateType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.CertificateName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Input.CertificateNumber)
            .MaximumLength(100);

        RuleFor(x => x.Input.IssuingAuthority)
            .MaximumLength(150);

        RuleFor(x => x.Input.StoragePath)
            .MaximumLength(500);

    }
}
