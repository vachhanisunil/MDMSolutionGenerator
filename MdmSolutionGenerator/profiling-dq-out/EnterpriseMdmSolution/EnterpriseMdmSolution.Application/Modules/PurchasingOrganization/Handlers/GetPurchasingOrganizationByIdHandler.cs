using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PurchasingOrganization;

namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.Handlers;

public sealed class GetPurchasingOrganizationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetPurchasingOrganizationByIdQuery, PurchasingOrganizationDto?>
{
    public async Task<PurchasingOrganizationDto?> Handle(GetPurchasingOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<PurchasingOrganizationDto>(entity);
    }
}