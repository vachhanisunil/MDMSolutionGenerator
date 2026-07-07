using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class ExecuteVendorAnalysisRunCommandHandler(IVendorRunService runService)
    : IRequestHandler<ExecuteVendorAnalysisRunCommand>
{
    public async Task Handle(ExecuteVendorAnalysisRunCommand request, CancellationToken cancellationToken)
        => await runService.ExecuteAnalysisRunAsync(request.RunId, cancellationToken);
}