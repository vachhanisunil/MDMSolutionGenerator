using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Queries;

public sealed record GetMaterialDuplicateDrilldownQuery(Guid RunId, Guid ResultId) : IRequest<IReadOnlyList<MaterialDuplicateDrilldownDto>>;