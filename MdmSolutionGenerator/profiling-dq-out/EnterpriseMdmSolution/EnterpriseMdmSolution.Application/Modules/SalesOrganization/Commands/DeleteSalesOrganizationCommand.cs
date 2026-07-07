using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

public sealed record DeleteSalesOrganizationCommand(int Id) : IRequest<bool>;