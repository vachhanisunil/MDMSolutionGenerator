using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record RunVendorAnalysisCommand(string RunType, string TriggeredBy) : IRequest<Guid>;