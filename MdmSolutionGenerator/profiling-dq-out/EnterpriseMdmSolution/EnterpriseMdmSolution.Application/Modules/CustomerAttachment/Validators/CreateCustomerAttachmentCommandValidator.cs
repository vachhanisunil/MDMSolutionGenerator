using FluentValidation;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Validators;

public sealed class CreateCustomerAttachmentCommandValidator : AbstractValidator<CreateCustomerAttachmentCommand>
{
    public CreateCustomerAttachmentCommandValidator()
    {
        RuleFor(x => x.Input.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Input.DocumentType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Input.FileName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Input.ContentType)
            .MaximumLength(100);

        RuleFor(x => x.Input.StoragePath)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Input.UploadedOn)
            .NotEmpty();

    }
}
