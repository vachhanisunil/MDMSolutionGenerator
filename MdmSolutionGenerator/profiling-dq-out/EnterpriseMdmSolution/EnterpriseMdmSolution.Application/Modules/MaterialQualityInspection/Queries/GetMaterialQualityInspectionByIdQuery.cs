using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Queries;

public sealed record GetMaterialQualityInspectionByIdQuery(int Id) : IRequest<MaterialQualityInspectionDto?>;