using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.Commands;

public sealed record DeleteCustomerContactCommand(int Id) : IRequest<bool>;