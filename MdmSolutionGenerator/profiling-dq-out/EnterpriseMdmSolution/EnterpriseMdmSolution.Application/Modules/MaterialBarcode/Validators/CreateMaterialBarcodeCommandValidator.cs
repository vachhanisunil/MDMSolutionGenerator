using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Validators;

public sealed class CreateMaterialBarcodeCommandValidator : AbstractValidator<CreateMaterialBarcodeCommand>
{
    public CreateMaterialBarcodeCommandValidator()
    {
        RuleFor(x => x.Input.MaterialId)
            .NotEmpty();

        RuleFor(x => x.Input.BarcodeType)
            .NotEmpty()
            .MaximumLength(30)
            .Must(value => new[] { "EAN", "UPC", "QR", "Code128" }.Contains(value)).WithMessage("BarcodeType contains an unsupported value");

        RuleFor(x => x.Input.BarcodeValue)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Input.IsPrimary)
            .NotEmpty();

    }
}
