using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Queries;

public sealed record SearchVendorBankAccountsQuery(SearchVendorBankAccountDto Search) : IRequest<PagedResult<VendorBankAccountDto>>;