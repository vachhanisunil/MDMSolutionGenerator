using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorAddress;

namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.Handlers;

public sealed class CreateVendorAddressHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorAddressCommand, VendorAddressDto>
{
    public async Task<VendorAddressDto> Handle(CreateVendorAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorAddressDto>(entity);
    }
}