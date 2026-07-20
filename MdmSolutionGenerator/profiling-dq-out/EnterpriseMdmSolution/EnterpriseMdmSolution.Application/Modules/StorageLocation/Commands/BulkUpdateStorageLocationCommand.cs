using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Commands;

public sealed record BulkUpdateStorageLocationCommand(BulkUpdateStorageLocationDto Input) : IRequest<BulkStorageLocationOperationResultDto>;