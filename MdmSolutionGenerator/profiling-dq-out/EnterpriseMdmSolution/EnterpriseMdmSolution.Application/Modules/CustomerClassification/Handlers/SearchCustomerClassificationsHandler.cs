using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Handlers;

public sealed class SearchCustomerClassificationsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchCustomerClassificationsQuery, PagedResult<CustomerClassificationDto>>
{
    public async Task<PagedResult<CustomerClassificationDto>> Handle(SearchCustomerClassificationsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<CustomerClassificationDto>
        {
            Items = mapper.Map<IReadOnlyList<CustomerClassificationDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}