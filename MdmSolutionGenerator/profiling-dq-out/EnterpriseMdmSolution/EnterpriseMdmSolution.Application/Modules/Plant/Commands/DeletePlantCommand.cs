using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Plant.Commands;

public sealed record DeletePlantCommand(int Id) : IRequest<bool>;