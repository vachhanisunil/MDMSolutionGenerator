using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class SearchPaymentTermsHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchPaymentTermsQuery, PagedResult<PaymentTermDto>>
{
    public async Task<PagedResult<PaymentTermDto>> Handle(SearchPaymentTermsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<PaymentTermDto>
        {
            Items = mapper.Map<IReadOnlyList<PaymentTermDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}