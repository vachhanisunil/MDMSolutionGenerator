using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Commands;

public sealed record CreatePlantCommand(CreatePlantDto Input) : IRequest<PlantDto>;