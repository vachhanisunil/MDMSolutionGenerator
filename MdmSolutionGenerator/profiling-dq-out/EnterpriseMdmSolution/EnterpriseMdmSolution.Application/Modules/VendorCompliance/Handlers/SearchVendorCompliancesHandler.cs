using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Handlers;

public sealed class SearchVendorCompliancesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorCompliancesQuery, PagedResult<VendorComplianceDto>>
{
    public async Task<PagedResult<VendorComplianceDto>> Handle(SearchVendorCompliancesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorComplianceDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorComplianceDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}