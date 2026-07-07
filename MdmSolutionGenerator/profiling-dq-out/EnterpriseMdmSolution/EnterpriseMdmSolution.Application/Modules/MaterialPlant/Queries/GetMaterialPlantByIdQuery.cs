using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.Queries;

public sealed record GetMaterialPlantByIdQuery(int Id) : IRequest<MaterialPlantDto?>;