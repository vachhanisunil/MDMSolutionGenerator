using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;

public sealed record UpdateCustomerSalesAreaCommand(int Id, UpdateCustomerSalesAreaDto Input) : IRequest<CustomerSalesAreaDto?>;