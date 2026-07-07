using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;

public sealed record CreateVendorTaxCommand(CreateVendorTaxDto Input) : IRequest<VendorTaxDto>;