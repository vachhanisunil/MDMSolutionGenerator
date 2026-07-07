using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;

public sealed record CreateCustomerSalesAreaCommand(CreateCustomerSalesAreaDto Input) : IRequest<CustomerSalesAreaDto>;