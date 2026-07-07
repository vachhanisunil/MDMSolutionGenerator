using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Queries;

public sealed record GetMaterialForecastByIdQuery(int Id) : IRequest<MaterialForecastDto?>;