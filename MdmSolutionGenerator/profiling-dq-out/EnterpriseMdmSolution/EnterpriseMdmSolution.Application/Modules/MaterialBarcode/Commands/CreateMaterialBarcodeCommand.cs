using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;

public sealed record CreateMaterialBarcodeCommand(CreateMaterialBarcodeDto Input) : IRequest<MaterialBarcodeDto>;