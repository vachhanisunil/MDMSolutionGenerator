using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Queries;

public sealed record SearchMaterialForecastsQuery(SearchMaterialForecastDto Search) : IRequest<PagedResult<MaterialForecastDto>>;