using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record RunMaterialAnalysisCommand(string RunType, string TriggeredBy) : IRequest<Guid>;