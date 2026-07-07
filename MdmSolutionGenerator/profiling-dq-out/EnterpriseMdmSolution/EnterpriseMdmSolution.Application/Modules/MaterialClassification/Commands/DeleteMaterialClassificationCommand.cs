using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.Commands;

public sealed record DeleteMaterialClassificationCommand(int Id) : IRequest<bool>;