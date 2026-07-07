using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialBarcode;

namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.Handlers;

public sealed class SearchMaterialBarcodesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialBarcodesQuery, PagedResult<MaterialBarcodeDto>>
{
    public async Task<PagedResult<MaterialBarcodeDto>> Handle(SearchMaterialBarcodesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialBarcodeDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialBarcodeDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}