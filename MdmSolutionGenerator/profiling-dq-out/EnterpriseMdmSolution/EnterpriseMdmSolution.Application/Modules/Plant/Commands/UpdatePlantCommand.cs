using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Commands;

public sealed record UpdatePlantCommand(int Id, UpdatePlantDto Input) : IRequest<PlantDto?>;