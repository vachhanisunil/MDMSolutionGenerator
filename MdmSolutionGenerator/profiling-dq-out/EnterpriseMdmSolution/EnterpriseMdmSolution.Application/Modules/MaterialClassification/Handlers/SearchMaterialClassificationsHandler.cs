using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialClassification;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Handlers;

public sealed class SearchMaterialClassificationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialClassificationsQuery, PagedResult<MaterialClassificationDto>>
{
    public async Task<PagedResult<MaterialClassificationDto>> Handle(SearchMaterialClassificationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialClassificationDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialClassificationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}