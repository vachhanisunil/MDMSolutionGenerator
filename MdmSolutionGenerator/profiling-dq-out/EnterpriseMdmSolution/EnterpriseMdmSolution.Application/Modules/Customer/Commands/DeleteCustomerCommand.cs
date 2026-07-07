using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record DeleteCustomerCommand(int Id) : IRequest<bool>;