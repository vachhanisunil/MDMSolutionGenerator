using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

public sealed record DeleteUnitOfMeasureCommand(int Id) : IRequest<bool>;