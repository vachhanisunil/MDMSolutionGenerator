using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;
using EnterpriseMdmSolution.Application.Modules.Plant.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Plant;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Handlers;

public sealed class SearchPlantsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchPlantsQuery, PagedResult<PlantDto>>
{
    public async Task<PagedResult<PlantDto>> Handle(SearchPlantsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<PlantDto>
        {
            Items = mapper.Map<IReadOnlyList<PlantDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}