using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialDuplicateDrilldownQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialDuplicateDrilldownQuery, IReadOnlyList<MaterialDuplicateDrilldownDto>>
{
    public async Task<IReadOnlyList<MaterialDuplicateDrilldownDto>> Handle(GetMaterialDuplicateDrilldownQuery request, CancellationToken cancellationToken)
        => await runService.GetDuplicateDrilldownAsync(request.RunId, request.ResultId, cancellationToken);
}