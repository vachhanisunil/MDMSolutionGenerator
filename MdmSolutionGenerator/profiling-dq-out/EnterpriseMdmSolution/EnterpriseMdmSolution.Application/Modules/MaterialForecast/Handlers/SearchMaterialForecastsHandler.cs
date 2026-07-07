using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialForecast;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Handlers;

public sealed class SearchMaterialForecastsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialForecastsQuery, PagedResult<MaterialForecastDto>>
{
    public async Task<PagedResult<MaterialForecastDto>> Handle(SearchMaterialForecastsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialForecastDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialForecastDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}