using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialPlant;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Handlers;

public sealed class SearchMaterialPlantsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialPlantsQuery, PagedResult<MaterialPlantDto>>
{
    public async Task<PagedResult<MaterialPlantDto>> Handle(SearchMaterialPlantsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialPlantDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialPlantDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}