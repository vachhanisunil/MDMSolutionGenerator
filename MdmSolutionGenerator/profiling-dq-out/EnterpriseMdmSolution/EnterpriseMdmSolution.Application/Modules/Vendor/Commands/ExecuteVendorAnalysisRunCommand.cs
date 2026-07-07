using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Commands;

public sealed record ExecuteVendorAnalysisRunCommand(Guid RunId) : IRequest;