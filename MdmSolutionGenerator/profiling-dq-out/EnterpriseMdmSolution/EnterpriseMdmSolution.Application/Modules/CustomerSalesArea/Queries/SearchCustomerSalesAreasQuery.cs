using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Queries;

public sealed record SearchCustomerSalesAreasQuery(SearchCustomerSalesAreaDto Search) : IRequest<PagedResult<CustomerSalesAreaDto>>;