using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class RunVendorAnalysisCommandHandler(IVendorRunService runService)
    : IRequestHandler<RunVendorAnalysisCommand, Guid>
{
    public async Task<Guid> Handle(RunVendorAnalysisCommand request, CancellationToken cancellationToken)
        => await runService.QueueAnalysisRunAsync(request.RunType, request.TriggeredBy, cancellationToken);
}