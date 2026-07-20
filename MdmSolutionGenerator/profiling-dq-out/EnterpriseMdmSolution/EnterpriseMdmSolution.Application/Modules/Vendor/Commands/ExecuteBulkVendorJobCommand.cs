using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record ExecuteBulkVendorJobCommand(Guid JobId) : IRequest;