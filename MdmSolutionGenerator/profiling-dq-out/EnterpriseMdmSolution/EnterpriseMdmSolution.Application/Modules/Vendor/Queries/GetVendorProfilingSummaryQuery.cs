using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

public sealed record GetVendorProfilingSummaryQuery(Guid RunId) : IRequest<IReadOnlyList<VendorProfilingSummaryDto>>;