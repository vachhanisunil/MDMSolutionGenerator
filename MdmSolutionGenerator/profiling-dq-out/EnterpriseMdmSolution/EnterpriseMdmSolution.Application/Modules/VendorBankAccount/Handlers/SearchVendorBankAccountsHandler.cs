using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorBankAccount;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Handlers;

public sealed class SearchVendorBankAccountsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorBankAccountsQuery, PagedResult<VendorBankAccountDto>>
{
    public async Task<PagedResult<VendorBankAccountDto>> Handle(SearchVendorBankAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorBankAccountDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorBankAccountDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}