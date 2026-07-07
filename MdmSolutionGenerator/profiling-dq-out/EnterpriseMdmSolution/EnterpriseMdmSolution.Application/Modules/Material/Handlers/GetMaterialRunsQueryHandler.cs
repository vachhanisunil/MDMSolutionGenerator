using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialRunsQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialRunsQuery, IReadOnlyList<MaterialRunDto>>
{
    public async Task<IReadOnlyList<MaterialRunDto>> Handle(GetMaterialRunsQuery request, CancellationToken cancellationToken)
        => await runService.GetRunsAsync(cancellationToken);
}