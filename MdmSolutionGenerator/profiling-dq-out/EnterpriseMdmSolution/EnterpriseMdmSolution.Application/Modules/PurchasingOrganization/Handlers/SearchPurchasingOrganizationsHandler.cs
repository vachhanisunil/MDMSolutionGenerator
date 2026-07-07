using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class SearchPurchasingOrganizationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchPurchasingOrganizationsQuery, PagedResult<PurchasingOrganizationDto>>
{
    public async Task<PagedResult<PurchasingOrganizationDto>> Handle(SearchPurchasingOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<PurchasingOrganizationDto>
        {
            Items = mapper.Map<IReadOnlyList<PurchasingOrganizationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}