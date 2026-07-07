using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Commands;

public sealed record DeleteCurrencyCommand(int Id) : IRequest<bool>;