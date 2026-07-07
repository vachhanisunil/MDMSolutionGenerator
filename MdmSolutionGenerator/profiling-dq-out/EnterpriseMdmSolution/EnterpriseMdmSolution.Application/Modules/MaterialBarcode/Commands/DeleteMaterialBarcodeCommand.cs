using MediatR;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Commands;

public sealed record DeleteMaterialBarcodeCommand(int Id) : IRequest<bool>;