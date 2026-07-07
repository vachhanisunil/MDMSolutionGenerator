using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialStorage;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Handlers;

public sealed class SearchMaterialStoragesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialStoragesQuery, PagedResult<MaterialStorageDto>>
{
    public async Task<PagedResult<MaterialStorageDto>> Handle(SearchMaterialStoragesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialStorageDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialStorageDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}