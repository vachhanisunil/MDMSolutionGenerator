using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;

public sealed record DeleteCustomerBankAccountCommand(int Id) : IRequest<bool>;