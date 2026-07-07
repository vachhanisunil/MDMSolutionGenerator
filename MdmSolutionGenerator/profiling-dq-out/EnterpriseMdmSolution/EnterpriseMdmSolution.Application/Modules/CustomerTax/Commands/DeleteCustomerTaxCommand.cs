using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;

public sealed record DeleteCustomerTaxCommand(int Id) : IRequest<bool>;