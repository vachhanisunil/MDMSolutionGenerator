using MediatR;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.Country.Commands;

public sealed record UpdateCountryCommand(int Id, UpdateCountryDto Input) : IRequest<CountryDto?>;