using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.Handlers;

public sealed class UpdateVendorPurchasingOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorPurchasingOrganizationCommand, VendorPurchasingOrganizationDto?>
{
    public async Task<VendorPurchasingOrganizationDto?> Handle(UpdateVendorPurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorPurchasingOrganizationDto>(entity);
    }
}