using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class GetSalesOrganizationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetSalesOrganizationByIdQuery, SalesOrganizationDto?>
{
    public async Task<SalesOrganizationDto?> Handle(GetSalesOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<SalesOrganizationDto>(entity);
    }
}