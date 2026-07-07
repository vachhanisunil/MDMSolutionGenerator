using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Commands;

public sealed record UpdateMaterialPlantCommand(int Id, UpdateMaterialPlantDto Input) : IRequest<MaterialPlantDto?>;