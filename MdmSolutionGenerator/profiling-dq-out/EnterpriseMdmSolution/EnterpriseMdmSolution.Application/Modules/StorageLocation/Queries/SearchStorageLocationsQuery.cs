using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.StorageLocation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.StorageLocation.Queries;

public sealed record SearchStorageLocationsQuery(SearchStorageLocationDto Search) : IRequest<PagedResult<StorageLocationDto>>;