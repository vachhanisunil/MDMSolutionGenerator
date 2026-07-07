using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Queries;

public sealed record SearchCustomerTaxsQuery(SearchCustomerTaxDto Search) : IRequest<PagedResult<CustomerTaxDto>>;