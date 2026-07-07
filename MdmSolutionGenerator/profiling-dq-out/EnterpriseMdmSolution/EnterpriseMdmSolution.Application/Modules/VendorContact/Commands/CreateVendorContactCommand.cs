using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;

public sealed record CreateVendorContactCommand(CreateVendorContactDto Input) : IRequest<VendorContactDto>;