using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Commands;

public sealed record BulkUpdatePlantCommand(BulkUpdatePlantDto Input) : IRequest<BulkPlantOperationResultDto>;