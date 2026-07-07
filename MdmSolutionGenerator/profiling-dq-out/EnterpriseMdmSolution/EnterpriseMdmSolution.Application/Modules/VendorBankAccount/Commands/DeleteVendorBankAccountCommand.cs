using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorBankAccount.Commands;

public sealed record DeleteVendorBankAccountCommand(int Id) : IRequest<bool>;