using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Queries;

public sealed record GetBulkVendorJobQuery(Guid JobId) : IRequest<BulkVendorJobDto?>;