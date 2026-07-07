using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.Vendor.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class SearchVendorsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorsQuery, PagedResult<VendorDto>>
{
    public async Task<PagedResult<VendorDto>> Handle(SearchVendorsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}