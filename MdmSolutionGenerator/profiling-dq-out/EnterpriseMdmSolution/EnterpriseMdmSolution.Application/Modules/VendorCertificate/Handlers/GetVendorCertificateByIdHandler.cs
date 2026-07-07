using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Handlers;

public sealed class GetVendorCertificateByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorCertificateByIdQuery, VendorCertificateDto?>
{
    public async Task<VendorCertificateDto?> Handle(GetVendorCertificateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorCertificateDto>(entity);
    }
}