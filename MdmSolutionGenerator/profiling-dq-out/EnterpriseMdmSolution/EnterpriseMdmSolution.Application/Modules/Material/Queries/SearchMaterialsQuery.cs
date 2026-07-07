using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Material.Queries;

public sealed record SearchMaterialsQuery(SearchMaterialDto Search) : IRequest<PagedResult<MaterialDto>>;