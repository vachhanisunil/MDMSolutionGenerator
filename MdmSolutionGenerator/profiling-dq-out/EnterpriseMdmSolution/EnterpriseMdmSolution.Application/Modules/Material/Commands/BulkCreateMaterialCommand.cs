using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record BulkCreateMaterialCommand(BulkCreateMaterialDto Input) : IRequest<BulkMaterialJobDto>;