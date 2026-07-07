using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Handlers;

public sealed class SearchCustomerSalesAreasHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerSalesAreasQuery, PagedResult<CustomerSalesAreaDto>>
{
    public async Task<PagedResult<CustomerSalesAreaDto>> Handle(SearchCustomerSalesAreasQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerSalesAreaDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerSalesAreaDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}