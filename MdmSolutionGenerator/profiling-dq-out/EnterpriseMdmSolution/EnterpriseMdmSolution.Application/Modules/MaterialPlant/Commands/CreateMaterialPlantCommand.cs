using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;

public sealed record CreateMaterialPlantCommand(CreateMaterialPlantDto Input) : IRequest<MaterialPlantDto>;