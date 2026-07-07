using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;

public sealed record UpdateMaterialQualityInspectionCommand(int Id, UpdateMaterialQualityInspectionDto Input) : IRequest<MaterialQualityInspectionDto?>;