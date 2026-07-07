using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.Queries;

public sealed record SearchMaterialUOMsQuery(SearchMaterialUOMDto Search) : IRequest<PagedResult<MaterialUOMDto>>;