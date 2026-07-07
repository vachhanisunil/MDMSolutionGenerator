using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Queries;

public sealed record SearchCustomersQuery(SearchCustomerDto Search) : IRequest<PagedResult<CustomerDto>>;