using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Handlers;

public sealed class SearchVendorContactsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorContactsQuery, PagedResult<VendorContactDto>>
{
    public async Task<PagedResult<VendorContactDto>> Handle(SearchVendorContactsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorContactDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorContactDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}