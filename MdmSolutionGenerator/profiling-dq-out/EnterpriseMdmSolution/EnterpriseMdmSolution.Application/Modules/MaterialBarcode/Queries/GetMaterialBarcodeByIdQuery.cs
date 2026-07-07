using MediatR;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Queries;

public sealed record GetMaterialBarcodeByIdQuery(int Id) : IRequest<MaterialBarcodeDto?>;