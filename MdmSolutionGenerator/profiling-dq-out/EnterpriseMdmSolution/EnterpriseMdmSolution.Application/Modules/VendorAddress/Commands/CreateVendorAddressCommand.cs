using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;

public sealed record CreateVendorAddressCommand(CreateVendorAddressDto Input) : IRequest<VendorAddressDto>;