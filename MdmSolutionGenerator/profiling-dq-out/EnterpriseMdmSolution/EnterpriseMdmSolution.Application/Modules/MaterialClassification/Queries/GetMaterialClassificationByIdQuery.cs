using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Queries;

public sealed record GetMaterialClassificationByIdQuery(int Id) : IRequest<MaterialClassificationDto?>;