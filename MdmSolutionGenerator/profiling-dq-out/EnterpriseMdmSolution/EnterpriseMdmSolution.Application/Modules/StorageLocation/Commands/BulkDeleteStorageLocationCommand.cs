using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

public sealed record BulkDeleteStorageLocationCommand(BulkDeleteStorageLocationDto Input) : IRequest<BulkStorageLocationOperationResultDto>;