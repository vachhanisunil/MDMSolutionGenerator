using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Queries;

public sealed record GetMaterialRuleDrilldownQuery(Guid RunId) : IRequest<IReadOnlyList<MaterialRuleDrilldownDto>>;