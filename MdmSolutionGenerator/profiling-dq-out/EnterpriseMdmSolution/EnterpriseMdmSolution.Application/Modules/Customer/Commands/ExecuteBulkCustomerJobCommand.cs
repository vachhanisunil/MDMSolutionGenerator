using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record ExecuteBulkCustomerJobCommand(Guid JobId) : IRequest;