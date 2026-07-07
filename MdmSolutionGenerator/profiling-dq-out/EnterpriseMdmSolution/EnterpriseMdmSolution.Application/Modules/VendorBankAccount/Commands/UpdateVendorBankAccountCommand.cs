using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;

public sealed record UpdateVendorBankAccountCommand(int Id, UpdateVendorBankAccountDto Input) : IRequest<VendorBankAccountDto?>;