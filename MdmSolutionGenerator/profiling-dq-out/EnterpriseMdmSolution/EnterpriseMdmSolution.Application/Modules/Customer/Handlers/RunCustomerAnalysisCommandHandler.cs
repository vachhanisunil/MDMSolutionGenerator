using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class RunCustomerAnalysisCommandHandler(ICustomerRunService runService)
    : IRequestHandler<RunCustomerAnalysisCommand, Guid>
{
    public async Task<Guid> Handle(RunCustomerAnalysisCommand request, CancellationToken cancellationToken)
        => await runService.QueueAnalysisRunAsync(request.RunType, request.TriggeredBy, cancellationToken);
}