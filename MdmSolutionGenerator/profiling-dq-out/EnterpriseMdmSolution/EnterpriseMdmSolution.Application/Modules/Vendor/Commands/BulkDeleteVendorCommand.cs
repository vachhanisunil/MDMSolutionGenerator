using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record BulkDeleteVendorCommand(BulkDeleteVendorDto Input) : IRequest<BulkVendorOperationResultDto>;