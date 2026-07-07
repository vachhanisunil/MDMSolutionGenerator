using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;

public sealed record UpdateVendorAddressCommand(int Id, UpdateVendorAddressDto Input) : IRequest<VendorAddressDto?>;