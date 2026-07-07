using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;

public sealed record DeleteCustomerAttachmentCommand(int Id) : IRequest<bool>;