using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;

public sealed record UpdateMaterialBarcodeCommand(int Id, UpdateMaterialBarcodeDto Input) : IRequest<MaterialBarcodeDto?>;