using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Plant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Queries;

public sealed record SearchPlantsQuery(SearchPlantDto Search) : IRequest<PagedResult<PlantDto>>;