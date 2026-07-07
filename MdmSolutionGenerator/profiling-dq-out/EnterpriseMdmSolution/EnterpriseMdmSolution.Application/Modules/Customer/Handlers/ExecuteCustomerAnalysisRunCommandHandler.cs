using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.Interfaces;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class ExecuteCustomerAnalysisRunCommandHandler(ICustomerRunService runService)
    : IRequestHandler<ExecuteCustomerAnalysisRunCommand>
{
    public async Task Handle(ExecuteCustomerAnalysisRunCommand request, CancellationToken cancellationToken)
        => await runService.ExecuteAnalysisRunAsync(request.RunId, cancellationToken);
}