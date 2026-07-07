using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Country.Queries;

public sealed record GetCountryByIdQuery(int Id) : IRequest<CountryDto?>;