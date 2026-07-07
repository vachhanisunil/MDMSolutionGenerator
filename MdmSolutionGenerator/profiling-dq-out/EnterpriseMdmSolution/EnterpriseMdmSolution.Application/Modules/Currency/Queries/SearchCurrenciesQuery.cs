using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Queries;

public sealed record SearchCurrenciesQuery(SearchCurrencyDto Search) : IRequest<PagedResult<CurrencyDto>>;