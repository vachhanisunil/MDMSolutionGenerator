using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class ExecuteMaterialAnalysisRunCommandHandler(IMaterialRunService runService)
    : IRequestHandler<ExecuteMaterialAnalysisRunCommand>
{
    public async Task Handle(ExecuteMaterialAnalysisRunCommand request, CancellationToken cancellationToken)
        => await runService.ExecuteAnalysisRunAsync(request.RunId, cancellationToken);
}