using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Queries;

public sealed record SearchMaterialPlantsQuery(SearchMaterialPlantDto Search) : IRequest<PagedResult<MaterialPlantDto>>;