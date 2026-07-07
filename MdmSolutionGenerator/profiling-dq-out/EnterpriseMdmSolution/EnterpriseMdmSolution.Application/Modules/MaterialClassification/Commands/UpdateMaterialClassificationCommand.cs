using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;

public sealed record UpdateMaterialClassificationCommand(int Id, UpdateMaterialClassificationDto Input) : IRequest<MaterialClassificationDto?>;