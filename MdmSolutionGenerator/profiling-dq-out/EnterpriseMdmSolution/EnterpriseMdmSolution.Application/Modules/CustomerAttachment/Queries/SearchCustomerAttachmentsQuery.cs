using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Queries;

public sealed record SearchCustomerAttachmentsQuery(SearchCustomerAttachmentDto Search) : IRequest<PagedResult<CustomerAttachmentDto>>;