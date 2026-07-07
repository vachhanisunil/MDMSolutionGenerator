using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Commands;

public sealed record DeleteMaterialGroupCommand(int Id) : IRequest<bool>;