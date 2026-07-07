using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialProfilingSummaryQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialProfilingSummaryQuery, IReadOnlyList<MaterialProfilingSummaryDto>>
{
    public async Task<IReadOnlyList<MaterialProfilingSummaryDto>> Handle(GetMaterialProfilingSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetProfilingSummaryAsync(request.RunId, cancellationToken);
}