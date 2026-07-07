using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.Commands;

public sealed record DeleteMaterialForecastCommand(int Id) : IRequest<bool>;