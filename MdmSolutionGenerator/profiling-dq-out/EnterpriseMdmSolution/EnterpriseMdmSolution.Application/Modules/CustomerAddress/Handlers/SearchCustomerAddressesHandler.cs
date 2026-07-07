using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerAddress;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Handlers;

public sealed class SearchCustomerAddressesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerAddressesQuery, PagedResult<CustomerAddressDto>>
{
    public async Task<PagedResult<CustomerAddressDto>> Handle(SearchCustomerAddressesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerAddressDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerAddressDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}