using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

public sealed record UpdateStorageLocationCommand(int Id, UpdateStorageLocationDto Input) : IRequest<StorageLocationDto?>;