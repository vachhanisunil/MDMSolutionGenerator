using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialStorage.Queries;

public sealed record SearchMaterialStoragesQuery(SearchMaterialStorageDto Search) : IRequest<PagedResult<MaterialStorageDto>>;