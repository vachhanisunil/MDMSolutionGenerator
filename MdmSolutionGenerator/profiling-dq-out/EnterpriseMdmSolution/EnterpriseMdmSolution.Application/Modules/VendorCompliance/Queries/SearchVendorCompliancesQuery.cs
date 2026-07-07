using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Queries;

public sealed record SearchVendorCompliancesQuery(SearchVendorComplianceDto Search) : IRequest<PagedResult<VendorComplianceDto>>;