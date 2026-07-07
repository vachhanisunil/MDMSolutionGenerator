using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Commands;

public sealed record DeleteMaterialStorageCommand(int Id) : IRequest<bool>;