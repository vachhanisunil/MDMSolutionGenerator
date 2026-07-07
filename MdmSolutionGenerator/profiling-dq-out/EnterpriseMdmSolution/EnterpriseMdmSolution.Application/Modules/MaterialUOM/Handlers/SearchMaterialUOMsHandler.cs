using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialUOM;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Handlers;

public sealed class SearchMaterialUOMsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialUOMsQuery, PagedResult<MaterialUOMDto>>
{
    public async Task<PagedResult<MaterialUOMDto>> Handle(SearchMaterialUOMsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialUOMDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialUOMDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}