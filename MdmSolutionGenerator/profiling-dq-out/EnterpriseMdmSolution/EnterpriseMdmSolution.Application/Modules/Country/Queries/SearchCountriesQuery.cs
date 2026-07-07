using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Country.Queries;

public sealed record SearchCountriesQuery(SearchCountryDto Search) : IRequest<PagedResult<CountryDto>>;