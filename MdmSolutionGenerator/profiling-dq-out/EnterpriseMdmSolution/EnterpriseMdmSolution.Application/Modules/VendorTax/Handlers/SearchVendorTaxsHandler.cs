using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorTax.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorTax;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Handlers;

public sealed class SearchVendorTaxsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorTaxsQuery, PagedResult<VendorTaxDto>>
{
    public async Task<PagedResult<VendorTaxDto>> Handle(SearchVendorTaxsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorTaxDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorTaxDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}