using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Commands;

public sealed record DeleteMaterialVendorCommand(int Id) : IRequest<bool>;