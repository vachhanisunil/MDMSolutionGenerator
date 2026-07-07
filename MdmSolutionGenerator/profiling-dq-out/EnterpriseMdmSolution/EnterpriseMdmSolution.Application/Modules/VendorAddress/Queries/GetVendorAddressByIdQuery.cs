using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Queries;

public sealed record GetVendorAddressByIdQuery(int Id) : IRequest<VendorAddressDto?>;