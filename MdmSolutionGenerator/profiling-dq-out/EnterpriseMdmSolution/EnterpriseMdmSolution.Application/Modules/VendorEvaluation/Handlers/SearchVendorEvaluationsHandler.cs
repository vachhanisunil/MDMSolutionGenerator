using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorEvaluation;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Handlers;

public sealed class SearchVendorEvaluationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorEvaluationsQuery, PagedResult<VendorEvaluationDto>>
{
    public async Task<PagedResult<VendorEvaluationDto>> Handle(SearchVendorEvaluationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorEvaluationDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorEvaluationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}