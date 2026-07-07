using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorEvaluation.Queries;

public sealed record SearchVendorEvaluationsQuery(SearchVendorEvaluationDto Search) : IRequest<PagedResult<VendorEvaluationDto>>;