using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialRuleDrilldownQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialRuleDrilldownQuery, IReadOnlyList<MaterialRuleDrilldownDto>>
{
    public async Task<IReadOnlyList<MaterialRuleDrilldownDto>> Handle(GetMaterialRuleDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleDrilldownAsync(request.RunId, request.ResultId, cancellationToken);
}