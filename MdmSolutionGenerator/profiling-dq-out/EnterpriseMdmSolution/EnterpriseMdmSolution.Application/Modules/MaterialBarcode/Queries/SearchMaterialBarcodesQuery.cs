using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Queries;

public sealed record SearchMaterialBarcodesQuery(SearchMaterialBarcodeDto Search) : IRequest<PagedResult<MaterialBarcodeDto>>;