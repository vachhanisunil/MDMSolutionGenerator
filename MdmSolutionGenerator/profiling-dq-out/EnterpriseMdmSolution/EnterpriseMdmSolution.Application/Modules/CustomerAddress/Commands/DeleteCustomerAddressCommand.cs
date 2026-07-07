using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.Commands;

public sealed record DeleteCustomerAddressCommand(int Id) : IRequest<bool>;