using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record BulkUpsertVendorCommand(BulkUpsertVendorDto Input) : IRequest<BulkVendorJobDto>;