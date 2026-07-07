using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Queries;

public sealed record SearchPaymentTermsQuery(SearchPaymentTermDto Search) : IRequest<PagedResult<PaymentTermDto>>;