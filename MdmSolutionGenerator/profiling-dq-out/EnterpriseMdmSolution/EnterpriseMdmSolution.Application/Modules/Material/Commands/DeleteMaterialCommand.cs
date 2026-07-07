using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Material.Commands;

public sealed record DeleteMaterialCommand(int Id) : IRequest<bool>;