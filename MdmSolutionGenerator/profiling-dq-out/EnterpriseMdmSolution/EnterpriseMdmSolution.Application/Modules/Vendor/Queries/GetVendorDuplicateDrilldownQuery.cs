using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

public sealed record GetVendorDuplicateDrilldownQuery(Guid RunId, Guid ResultId) : IRequest<IReadOnlyList<VendorDuplicateDrilldownDto>>;