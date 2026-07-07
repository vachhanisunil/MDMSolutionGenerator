using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class SearchMaterialsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialsQuery, PagedResult<MaterialDto>>
{
    public async Task<PagedResult<MaterialDto>> Handle(SearchMaterialsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}