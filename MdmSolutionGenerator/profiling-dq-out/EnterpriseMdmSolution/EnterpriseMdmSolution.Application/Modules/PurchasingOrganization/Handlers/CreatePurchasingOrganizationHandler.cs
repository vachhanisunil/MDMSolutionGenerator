using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class CreatePurchasingOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreatePurchasingOrganizationCommand, PurchasingOrganizationDto>
{
    public async Task<PurchasingOrganizationDto> Handle(CreatePurchasingOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<PurchasingOrganizationDto>(entity);
    }
}