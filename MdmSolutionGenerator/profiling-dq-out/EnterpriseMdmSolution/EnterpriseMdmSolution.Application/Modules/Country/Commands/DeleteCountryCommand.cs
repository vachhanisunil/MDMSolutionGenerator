using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Country.Commands;

public sealed record DeleteCountryCommand(int Id) : IRequest<bool>;