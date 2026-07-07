using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;

public sealed record UpdateMaterialForecastCommand(int Id, UpdateMaterialForecastDto Input) : IRequest<MaterialForecastDto?>;