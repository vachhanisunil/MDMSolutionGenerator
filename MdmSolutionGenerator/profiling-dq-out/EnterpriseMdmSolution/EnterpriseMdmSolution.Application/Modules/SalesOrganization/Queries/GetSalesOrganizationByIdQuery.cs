using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Queries;

public sealed record GetSalesOrganizationByIdQuery(int Id) : IRequest<SalesOrganizationDto?>;