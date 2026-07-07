using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorContact.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorContact;

namespace EnterpriseMdmSolution.Application.Modules.VendorContact.Handlers;

public sealed class CreateVendorContactHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorContactCommand, VendorContactDto>
{
    public async Task<VendorContactDto> Handle(CreateVendorContactCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorContactDto>(entity);
    }
}