using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Handlers;

public sealed class SearchVendorAddressesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorAddressesQuery, PagedResult<VendorAddressDto>>
{
    public async Task<PagedResult<VendorAddressDto>> Handle(SearchVendorAddressesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorAddressDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorAddressDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}