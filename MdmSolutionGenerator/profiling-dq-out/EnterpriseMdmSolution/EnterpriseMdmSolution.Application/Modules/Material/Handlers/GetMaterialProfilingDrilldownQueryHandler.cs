using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialProfilingDrilldownQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialProfilingDrilldownQuery, IReadOnlyList<MaterialProfilingDrilldownDto>>
{
    public async Task<IReadOnlyList<MaterialProfilingDrilldownDto>> Handle(GetMaterialProfilingDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingDrilldownAsync(request.RunId, request.SummaryId, cancellationToken);
}