using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs;
using EnterpriseMdmSolution.Application.Modules.MaterialVendor.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.MaterialVendor;

namespace EnterpriseMdmSolution.Application.Modules.MaterialVendor.Handlers;

public sealed class SearchMaterialVendorsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchMaterialVendorsQuery, PagedResult<MaterialVendorDto>>
{
    public async Task<PagedResult<MaterialVendorDto>> Handle(SearchMaterialVendorsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<MaterialVendorDto>
        {
            Items = mapper.Map<IReadOnlyList<MaterialVendorDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}