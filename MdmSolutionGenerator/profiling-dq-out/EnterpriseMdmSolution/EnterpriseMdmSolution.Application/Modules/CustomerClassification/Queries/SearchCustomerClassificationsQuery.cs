using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Queries;

public sealed record SearchCustomerClassificationsQuery(SearchCustomerClassificationDto Search) : IRequest<PagedResult<CustomerClassificationDto>>;