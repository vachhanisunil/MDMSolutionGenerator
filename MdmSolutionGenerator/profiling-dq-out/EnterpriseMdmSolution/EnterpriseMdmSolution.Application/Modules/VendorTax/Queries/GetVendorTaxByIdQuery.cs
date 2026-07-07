using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorTax.Queries;

public sealed record GetVendorTaxByIdQuery(int Id) : IRequest<VendorTaxDto?>;