using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Queries;

public sealed record GetMaterialProfilingDrilldownQuery(Guid RunId, Guid SummaryId) : IRequest<IReadOnlyList<MaterialProfilingDrilldownDto>>;