using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Queries;

public sealed record GetCustomerAttachmentByIdQuery(int Id) : IRequest<CustomerAttachmentDto?>;