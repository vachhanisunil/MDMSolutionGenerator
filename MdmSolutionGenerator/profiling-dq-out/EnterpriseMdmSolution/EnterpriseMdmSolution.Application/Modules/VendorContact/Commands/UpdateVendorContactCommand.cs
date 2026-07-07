using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;

public sealed record UpdateVendorContactCommand(int Id, UpdateVendorContactDto Input) : IRequest<VendorContactDto?>;