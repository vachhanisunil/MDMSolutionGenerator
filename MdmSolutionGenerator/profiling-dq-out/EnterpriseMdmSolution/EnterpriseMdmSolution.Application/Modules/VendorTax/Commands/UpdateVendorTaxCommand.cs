using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Commands;

public sealed record UpdateVendorTaxCommand(int Id, UpdateVendorTaxDto Input) : IRequest<VendorTaxDto?>;