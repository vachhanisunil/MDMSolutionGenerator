using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Queries;

public sealed record SearchCustomerBankAccountsQuery(SearchCustomerBankAccountDto Search) : IRequest<PagedResult<CustomerBankAccountDto>>;