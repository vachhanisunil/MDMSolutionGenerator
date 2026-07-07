using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Queries;

public sealed record GetCustomerSalesAreaByIdQuery(int Id) : IRequest<CustomerSalesAreaDto?>;