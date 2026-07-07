using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Handlers;

public sealed class UpdateVendorContactHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorContactCommand, VendorContactDto?>
{
    public async Task<VendorContactDto?> Handle(UpdateVendorContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorContactDto>(entity);
    }
}