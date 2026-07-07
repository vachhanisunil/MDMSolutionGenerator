using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.StorageLocation;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Handlers;

public sealed class SearchStorageLocationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchStorageLocationsQuery, PagedResult<StorageLocationDto>>
{
    public async Task<PagedResult<StorageLocationDto>> Handle(SearchStorageLocationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<StorageLocationDto>
        {
            Items = mapper.Map<IReadOnlyList<StorageLocationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}