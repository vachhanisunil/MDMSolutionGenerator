using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

public sealed record DeleteStorageLocationCommand(int Id) : IRequest<bool>;