using MediatR;
using EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.Commands;

public sealed record BulkUpsertUnitOfMeasureCommand(BulkUpsertUnitOfMeasureDto Input) : IRequest<BulkUnitOfMeasureOperationResultDto>;