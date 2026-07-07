using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;

public sealed record DeleteVendorTaxCommand(int Id) : IRequest<bool>;