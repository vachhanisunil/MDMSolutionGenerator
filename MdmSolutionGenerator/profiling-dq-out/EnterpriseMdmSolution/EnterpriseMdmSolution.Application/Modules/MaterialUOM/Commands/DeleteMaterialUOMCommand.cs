using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Commands;

public sealed record DeleteMaterialUOMCommand(int Id) : IRequest<bool>;