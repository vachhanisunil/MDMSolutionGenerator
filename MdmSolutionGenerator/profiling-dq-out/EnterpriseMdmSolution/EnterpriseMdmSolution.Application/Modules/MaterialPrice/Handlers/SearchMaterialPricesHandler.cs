using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPrice;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Handlers;

public sealed class SearchMaterialPricesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialPricesQuery, PagedResult<MaterialPriceDto>>
{
    public async Task<PagedResult<MaterialPriceDto>> Handle(SearchMaterialPricesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialPriceDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialPriceDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}