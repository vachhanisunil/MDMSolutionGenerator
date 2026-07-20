using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

public sealed record BulkUpdateMaterialGroupCommand(BulkUpdateMaterialGroupDto Input) : IRequest<BulkMaterialGroupOperationResultDto>;