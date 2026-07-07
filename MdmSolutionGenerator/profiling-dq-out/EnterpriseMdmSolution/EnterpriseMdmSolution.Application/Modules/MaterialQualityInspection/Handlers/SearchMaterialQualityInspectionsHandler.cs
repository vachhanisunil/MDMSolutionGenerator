using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Handlers;

public sealed class SearchMaterialQualityInspectionsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialQualityInspectionsQuery, PagedResult<MaterialQualityInspectionDto>>
{
    public async Task<PagedResult<MaterialQualityInspectionDto>> Handle(SearchMaterialQualityInspectionsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialQualityInspectionDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialQualityInspectionDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}