using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;

public sealed record UpdateMaterialVendorCommand(int Id, UpdateMaterialVendorDto Input) : IRequest<MaterialVendorDto?>;