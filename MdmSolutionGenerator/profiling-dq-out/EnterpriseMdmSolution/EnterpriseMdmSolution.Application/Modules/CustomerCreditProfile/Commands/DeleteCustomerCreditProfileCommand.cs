using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;

public sealed record DeleteCustomerCreditProfileCommand(int Id) : IRequest<bool>;