using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Handlers;

public sealed class CreateVendorPurchasingOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorPurchasingOrganizationCommand, VendorPurchasingOrganizationDto>
{
    public async Task<VendorPurchasingOrganizationDto> Handle(CreateVendorPurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorPurchasingOrganizationDto>(entity);
    }
}