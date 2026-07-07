using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class RunMaterialAnalysisCommandHandler(IMaterialRunService runService)
    : IRequestHandler<RunMaterialAnalysisCommand, Guid>
{
    public async Task<Guid> Handle(RunMaterialAnalysisCommand request, CancellationToken cancellationToken)
        => await runService.QueueAnalysisRunAsync(request.RunType, request.TriggeredBy, cancellationToken);
}