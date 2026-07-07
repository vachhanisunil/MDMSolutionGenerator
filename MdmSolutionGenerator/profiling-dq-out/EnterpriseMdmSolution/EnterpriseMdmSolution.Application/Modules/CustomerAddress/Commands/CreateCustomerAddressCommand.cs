using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;

public sealed record CreateCustomerAddressCommand(CreateCustomerAddressDto Input) : IRequest<CustomerAddressDto>;