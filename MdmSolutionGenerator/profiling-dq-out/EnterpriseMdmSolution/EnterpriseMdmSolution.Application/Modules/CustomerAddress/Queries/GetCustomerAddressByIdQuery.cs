using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Queries;

public sealed record GetCustomerAddressByIdQuery(int Id) : IRequest<CustomerAddressDto?>;