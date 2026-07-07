using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Handlers;

public sealed class SearchCustomerBankAccountsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerBankAccountsQuery, PagedResult<CustomerBankAccountDto>>
{
    public async Task<PagedResult<CustomerBankAccountDto>> Handle(SearchCustomerBankAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerBankAccountDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerBankAccountDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}