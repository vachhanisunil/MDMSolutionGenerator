using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record BulkUpsertMaterialCommand(BulkUpsertMaterialDto Input) : IRequest<BulkMaterialOperationResultDto>;