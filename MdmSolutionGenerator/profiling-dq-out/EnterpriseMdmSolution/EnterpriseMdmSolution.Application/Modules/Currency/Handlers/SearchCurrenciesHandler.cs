using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.Currency.DTOs;
using EnterpriseMdmSolution.Application.Modules.Currency.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Currency;

namespace EnterpriseMdmSolution.Application.Modules.Currency.Handlers;

public sealed class SearchCurrenciesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCurrenciesQuery, PagedResult<CurrencyDto>>
{
    public async Task<PagedResult<CurrencyDto>> Handle(SearchCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CurrencyDto>
        {
            Items = mapper.Map<IReadOnlyList<CurrencyDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}