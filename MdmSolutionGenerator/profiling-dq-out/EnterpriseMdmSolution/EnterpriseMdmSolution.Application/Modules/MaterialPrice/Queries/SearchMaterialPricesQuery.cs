using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.Queries;

public sealed record SearchMaterialPricesQuery(SearchMaterialPriceDto Search) : IRequest<PagedResult<MaterialPriceDto>>;