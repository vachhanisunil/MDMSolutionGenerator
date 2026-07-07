using MediatR;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Queries;

public sealed record GetCurrencyByIdQuery(int Id) : IRequest<CurrencyDto?>;