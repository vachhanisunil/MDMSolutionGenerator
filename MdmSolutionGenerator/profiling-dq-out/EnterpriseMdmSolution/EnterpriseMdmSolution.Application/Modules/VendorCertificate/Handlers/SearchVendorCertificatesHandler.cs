using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Core.Common;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Handlers;

public sealed class SearchVendorCertificatesHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<SearchVendorCertificatesQuery, PagedResult<VendorCertificateDto>>
{
    public async Task<PagedResult<VendorCertificateDto>> Handle(SearchVendorCertificatesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.SearchAsync(request.Search, cancellationToken);
        return new PagedResult<VendorCertificateDto>
        {
            Items = mapper.Map<IReadOnlyList<VendorCertificateDto>>(result.Items),
            TotalCount = result.TotalCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };
    }
}