using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Queries;

public sealed record GetCustomerClassificationByIdQuery(int Id) : IRequest<CustomerClassificationDto?>;