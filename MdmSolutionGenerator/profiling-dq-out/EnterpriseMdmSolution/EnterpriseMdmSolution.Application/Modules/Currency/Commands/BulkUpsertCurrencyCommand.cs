using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Commands;

public sealed record BulkUpsertCurrencyCommand(BulkUpsertCurrencyDto Input) : IRequest<BulkCurrencyOperationResultDto>;