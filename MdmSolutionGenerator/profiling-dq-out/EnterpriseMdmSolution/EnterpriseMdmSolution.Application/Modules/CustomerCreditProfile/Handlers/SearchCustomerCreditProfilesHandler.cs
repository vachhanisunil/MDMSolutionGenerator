using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Handlers;

public sealed class SearchCustomerCreditProfilesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerCreditProfilesQuery, PagedResult<CustomerCreditProfileDto>>
{
    public async Task<PagedResult<CustomerCreditProfileDto>> Handle(SearchCustomerCreditProfilesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerCreditProfileDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerCreditProfileDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}