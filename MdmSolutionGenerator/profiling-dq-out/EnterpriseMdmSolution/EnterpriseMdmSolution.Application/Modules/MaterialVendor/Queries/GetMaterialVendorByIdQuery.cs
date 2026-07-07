using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Queries;

public sealed record GetMaterialVendorByIdQuery(int Id) : IRequest<MaterialVendorDto?>;