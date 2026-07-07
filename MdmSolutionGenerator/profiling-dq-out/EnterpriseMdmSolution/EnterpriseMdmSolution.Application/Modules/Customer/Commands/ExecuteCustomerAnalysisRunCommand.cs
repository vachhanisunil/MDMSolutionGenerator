using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Commands;

public sealed record ExecuteCustomerAnalysisRunCommand(Guid RunId) : IRequest;