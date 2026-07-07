using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Commands;

public sealed record UpdateVendorEvaluationCommand(int Id, UpdateVendorEvaluationDto Input) : IRequest<VendorEvaluationDto?>;