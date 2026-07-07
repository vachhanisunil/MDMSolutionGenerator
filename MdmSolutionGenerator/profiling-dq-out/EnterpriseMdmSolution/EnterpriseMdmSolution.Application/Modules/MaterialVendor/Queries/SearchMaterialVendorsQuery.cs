using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Queries;

public sealed record SearchMaterialVendorsQuery(SearchMaterialVendorDto Search) : IRequest<PagedResult<MaterialVendorDto>>;