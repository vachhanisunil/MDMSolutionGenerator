using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.Commands;

public sealed record DeleteMaterialQualityInspectionCommand(int Id) : IRequest<bool>;