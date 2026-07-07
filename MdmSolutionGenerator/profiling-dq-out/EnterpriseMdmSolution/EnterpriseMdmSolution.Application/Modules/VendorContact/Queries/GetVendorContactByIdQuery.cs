using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Queries;

public sealed record GetVendorContactByIdQuery(int Id) : IRequest<VendorContactDto?>;