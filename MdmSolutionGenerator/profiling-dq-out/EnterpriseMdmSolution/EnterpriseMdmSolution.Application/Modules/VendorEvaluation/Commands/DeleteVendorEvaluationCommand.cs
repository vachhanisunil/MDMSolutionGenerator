using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;

public sealed record DeleteVendorEvaluationCommand(int Id) : IRequest<bool>;