using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record ExecuteBulkMaterialJobCommand(Guid JobId) : IRequest;