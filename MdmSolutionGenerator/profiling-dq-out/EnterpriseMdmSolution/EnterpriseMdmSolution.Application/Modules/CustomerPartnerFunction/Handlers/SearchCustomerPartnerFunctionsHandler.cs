using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Handlers;

public sealed class SearchCustomerPartnerFunctionsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerPartnerFunctionsQuery, PagedResult<CustomerPartnerFunctionDto>>
{
    public async Task<PagedResult<CustomerPartnerFunctionDto>> Handle(SearchCustomerPartnerFunctionsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerPartnerFunctionDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerPartnerFunctionDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}