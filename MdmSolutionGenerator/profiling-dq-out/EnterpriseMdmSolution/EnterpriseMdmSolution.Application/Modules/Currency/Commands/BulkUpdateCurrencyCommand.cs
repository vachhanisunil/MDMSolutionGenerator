using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Commands;

public sealed record BulkUpdateCurrencyCommand(BulkUpdateCurrencyDto Input) : IRequest<BulkCurrencyOperationResultDto>;