using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class UpdatePurchasingOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdatePurchasingOrganizationCommand, PurchasingOrganizationDto?>
{
    public async Task<PurchasingOrganizationDto?> Handle(UpdatePurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<PurchasingOrganizationDto>(entity);
    }
}