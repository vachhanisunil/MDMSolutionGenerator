using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Handlers;

public sealed class SearchVendorPurchasingOrganizationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorPurchasingOrganizationsQuery, PagedResult<VendorPurchasingOrganizationDto>>
{
    public async Task<PagedResult<VendorPurchasingOrganizationDto>> Handle(SearchVendorPurchasingOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorPurchasingOrganizationDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorPurchasingOrganizationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}