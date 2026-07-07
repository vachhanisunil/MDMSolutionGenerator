using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class SearchSalesOrganizationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchSalesOrganizationsQuery, PagedResult<SalesOrganizationDto>>
{
    public async Task<PagedResult<SalesOrganizationDto>> Handle(SearchSalesOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<SalesOrganizationDto>
        {
            Items = mapper.Map<IReadOnlyList<SalesOrganizationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}