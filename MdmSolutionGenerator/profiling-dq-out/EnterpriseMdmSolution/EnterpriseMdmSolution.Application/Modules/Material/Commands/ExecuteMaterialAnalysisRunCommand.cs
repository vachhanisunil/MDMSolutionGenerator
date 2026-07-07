using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record ExecuteMaterialAnalysisRunCommand(Guid RunId) : IRequest;