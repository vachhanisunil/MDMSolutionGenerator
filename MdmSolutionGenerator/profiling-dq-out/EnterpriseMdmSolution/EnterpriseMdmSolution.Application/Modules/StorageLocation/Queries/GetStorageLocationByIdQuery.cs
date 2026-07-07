using MediatR;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Queries;

public sealed record GetStorageLocationByIdQuery(int Id) : IRequest<StorageLocationDto?>;