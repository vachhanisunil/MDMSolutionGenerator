using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Commands;

public sealed record CreateCustomerAttachmentCommand(CreateCustomerAttachmentDto Input) : IRequest<CustomerAttachmentDto>;