using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record CreateCustomerCommand(CreateCustomerDto Input) : IRequest<CustomerDto>;