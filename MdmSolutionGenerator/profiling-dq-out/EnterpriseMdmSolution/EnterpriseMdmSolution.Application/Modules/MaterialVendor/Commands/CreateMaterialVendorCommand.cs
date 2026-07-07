using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;

public sealed record CreateMaterialVendorCommand(CreateMaterialVendorDto Input) : IRequest<MaterialVendorDto>;