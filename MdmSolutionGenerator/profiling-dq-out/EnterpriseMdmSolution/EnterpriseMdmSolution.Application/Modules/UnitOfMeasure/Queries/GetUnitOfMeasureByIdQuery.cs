using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Queries;

public sealed record GetUnitOfMeasureByIdQuery(int Id) : IRequest<UnitOfMeasureDto?>;