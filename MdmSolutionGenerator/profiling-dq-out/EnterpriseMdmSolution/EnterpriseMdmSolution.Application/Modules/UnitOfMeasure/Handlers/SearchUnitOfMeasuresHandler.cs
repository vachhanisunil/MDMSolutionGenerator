using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.UnitOfMeasure;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Handlers;

public sealed class SearchUnitOfMeasuresHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchUnitOfMeasuresQuery, PagedResult<UnitOfMeasureDto>>
{
    public async Task<PagedResult<UnitOfMeasureDto>> Handle(SearchUnitOfMeasuresQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<UnitOfMeasureDto>
        {
            Items = mapper.Map<IReadOnlyList<UnitOfMeasureDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}