using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.Queries;

public sealed record SearchMaterialGroupsQuery(SearchMaterialGroupDto Search) : IRequest<PagedResult<MaterialGroupDto>>;