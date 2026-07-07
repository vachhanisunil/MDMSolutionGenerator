using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

public sealed record CreateSalesOrganizationCommand(CreateSalesOrganizationDto Input) : IRequest<SalesOrganizationDto>;