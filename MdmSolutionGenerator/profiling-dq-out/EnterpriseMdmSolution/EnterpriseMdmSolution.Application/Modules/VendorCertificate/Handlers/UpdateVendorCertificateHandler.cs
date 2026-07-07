using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCertificate;

namespace EnterpriseMdmSolution.Application.Modules.VendorCertificate.Handlers;

public sealed class UpdateVendorCertificateHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorCertificateCommand, VendorCertificateDto?>
{
    public async Task<VendorCertificateDto?> Handle(UpdateVendorCertificateCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorCertificateDto>(entity);
    }
}