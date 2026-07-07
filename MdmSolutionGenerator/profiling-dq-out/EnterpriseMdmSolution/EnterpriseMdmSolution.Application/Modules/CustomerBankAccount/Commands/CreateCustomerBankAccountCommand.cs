using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Commands;

public sealed record CreateCustomerBankAccountCommand(CreateCustomerBankAccountDto Input) : IRequest<CustomerBankAccountDto>;