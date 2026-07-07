using MediatR;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Queries;

public sealed record GetPlantByIdQuery(int Id) : IRequest<PlantDto?>;