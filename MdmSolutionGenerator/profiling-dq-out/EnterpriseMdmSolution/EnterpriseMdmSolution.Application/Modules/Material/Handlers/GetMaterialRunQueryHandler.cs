using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Application.Modules.Material.Interfaces;
using EnterpriseMdmSolution.Application.Modules.Material.Queries;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class GetMaterialRunQueryHandler(IMaterialRunService runService)
    : IRequestHandler<GetMaterialRunQuery, MaterialRunDto?>
{
    public async Task<MaterialRunDto?> Handle(GetMaterialRunQuery request, CancellationToken cancellationToken)
        => await runService.GetRunAsync(request.RunId, cancellationToken);
}