using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

public sealed record UpdateUnitOfMeasureCommand(int Id, UpdateUnitOfMeasureDto Input) : IRequest<UnitOfMeasureDto?>;