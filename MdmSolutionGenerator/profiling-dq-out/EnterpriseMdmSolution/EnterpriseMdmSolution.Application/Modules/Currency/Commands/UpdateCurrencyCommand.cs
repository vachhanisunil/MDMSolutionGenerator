using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Commands;

public sealed record UpdateCurrencyCommand(int Id, UpdateCurrencyDto Input) : IRequest<CurrencyDto?>;