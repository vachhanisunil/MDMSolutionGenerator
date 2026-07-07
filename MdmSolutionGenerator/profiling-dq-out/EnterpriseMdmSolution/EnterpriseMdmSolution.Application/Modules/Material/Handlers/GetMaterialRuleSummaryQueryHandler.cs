using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialRuleSummaryQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialRuleSummaryQuery, IReadOnlyList<MaterialRuleSummaryDto>>
{
    public async Task<IReadOnlyList<MaterialRuleSummaryDto>> Handle(GetMaterialRuleSummaryQuery request, CancellationToken cancellationToken)
        => await runService.GetRuleSummaryAsync(request.RunId, cancellationToken);
}