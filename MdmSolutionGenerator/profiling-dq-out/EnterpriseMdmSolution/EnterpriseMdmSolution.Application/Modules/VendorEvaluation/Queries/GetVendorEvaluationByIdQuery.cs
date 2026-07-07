using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Queries;

public sealed record GetVendorEvaluationByIdQuery(int Id) : IRequest<VendorEvaluationDto?>;