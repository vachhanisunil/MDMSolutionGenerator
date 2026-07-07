using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Handlers;

public sealed class UpdateVendorAddressHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorAddressCommand, VendorAddressDto?>
{
    public async Task<VendorAddressDto?> Handle(UpdateVendorAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorAddressDto>(entity);
    }
}