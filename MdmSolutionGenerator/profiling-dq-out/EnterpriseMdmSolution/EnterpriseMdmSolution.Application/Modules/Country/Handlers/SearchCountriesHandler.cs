using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Country.DTOs;
using EnterpriseMdmSolution.Application.Modules.Country.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Country;

namespace EnterpriseMdmSolution.Application.Modules.Country.Handlers;

public sealed class SearchCountriesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCountriesQuery, PagedResult<CountryDto>>
{
    public async Task<PagedResult<CountryDto>> Handle(SearchCountriesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CountryDto>
        {
            Items = mapper.Map<IReadOnlyList<CountryDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}