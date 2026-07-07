using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerBankAccount.Queries;

public sealed record GetCustomerBankAccountByIdQuery(int Id) : IRequest<CustomerBankAccountDto?>;