using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Queries;

public sealed record SearchUnitOfMeasuresQuery(SearchUnitOfMeasureDto Search) : IRequest<PagedResult<UnitOfMeasureDto>>;