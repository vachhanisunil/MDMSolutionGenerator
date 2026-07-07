using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerContact.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerContact;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Handlers;

public sealed class SearchCustomerContactsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerContactsQuery, PagedResult<CustomerContactDto>>
{
    public async Task<PagedResult<CustomerContactDto>> Handle(SearchCustomerContactsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerContactDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerContactDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}