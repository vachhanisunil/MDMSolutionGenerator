using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record RunCustomerAnalysisCommand(string RunType, string TriggeredBy) : IRequest<Guid>;