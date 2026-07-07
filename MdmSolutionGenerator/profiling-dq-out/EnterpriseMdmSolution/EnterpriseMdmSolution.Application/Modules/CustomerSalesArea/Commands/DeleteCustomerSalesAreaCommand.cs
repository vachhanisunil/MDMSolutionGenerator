using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;

public sealed record DeleteCustomerSalesAreaCommand(int Id) : IRequest<bool>;