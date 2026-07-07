using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialGroup;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Handlers;

public sealed class SearchMaterialGroupsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialGroupsQuery, PagedResult<MaterialGroupDto>>
{
    public async Task<PagedResult<MaterialGroupDto>> Handle(SearchMaterialGroupsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialGroupDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialGroupDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}