using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Queries;

public sealed record GetVendorBankAccountByIdQuery(int Id) : IRequest<VendorBankAccountDto?>;