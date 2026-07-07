using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;

public sealed record CreateMaterialForecastCommand(CreateMaterialForecastDto Input) : IRequest<MaterialForecastDto>;