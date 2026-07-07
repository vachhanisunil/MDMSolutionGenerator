using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;

public sealed record CreateVendorBankAccountCommand(CreateVendorBankAccountDto Input) : IRequest<VendorBankAccountDto>;