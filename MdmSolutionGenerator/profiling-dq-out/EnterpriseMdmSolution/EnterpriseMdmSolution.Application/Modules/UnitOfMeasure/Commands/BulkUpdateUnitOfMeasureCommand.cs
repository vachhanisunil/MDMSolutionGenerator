using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

public sealed record BulkUpdateUnitOfMeasureCommand(BulkUpdateUnitOfMeasureDto Input) : IRequest<BulkUnitOfMeasureOperationResultDto>;