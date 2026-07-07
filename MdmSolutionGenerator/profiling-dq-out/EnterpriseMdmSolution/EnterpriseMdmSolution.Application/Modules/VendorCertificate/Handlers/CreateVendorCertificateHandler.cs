using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Handlers;

public sealed class CreateVendorCertificateHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorCertificateCommand, VendorCertificateDto>
{
    public async Task<VendorCertificateDto> Handle(CreateVendorCertificateCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorCertificateDto>(entity);
    }
}