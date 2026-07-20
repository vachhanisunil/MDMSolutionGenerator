using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Queries;

public sealed record GetBulkMaterialJobQuery(Guid JobId) : IRequest<BulkMaterialJobDto?>;