using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Handlers;

public sealed class SearchCustomerTaxsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerTaxsQuery, PagedResult<CustomerTaxDto>>
{
    public async Task<PagedResult<CustomerTaxDto>> Handle(SearchCustomerTaxsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerTaxDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerTaxDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}