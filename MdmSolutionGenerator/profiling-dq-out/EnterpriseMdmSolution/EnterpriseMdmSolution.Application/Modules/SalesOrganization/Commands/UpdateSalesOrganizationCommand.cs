using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;

public sealed record UpdateSalesOrganizationCommand(int Id, UpdateSalesOrganizationDto Input) : IRequest<SalesOrganizationDto?>;