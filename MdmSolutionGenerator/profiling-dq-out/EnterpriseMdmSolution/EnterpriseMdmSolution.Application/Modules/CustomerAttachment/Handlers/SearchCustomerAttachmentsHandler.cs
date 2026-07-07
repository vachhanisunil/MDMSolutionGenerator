using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAttachment;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAttachment.Handlers;

public sealed class SearchCustomerAttachmentsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerAttachmentsQuery, PagedResult<CustomerAttachmentDto>>
{
    public async Task<PagedResult<CustomerAttachmentDto>> Handle(SearchCustomerAttachmentsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerAttachmentDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerAttachmentDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}