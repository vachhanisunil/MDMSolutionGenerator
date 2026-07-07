using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class UpdateSalesOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateSalesOrganizationCommand, SalesOrganizationDto?>
{
    public async Task<SalesOrganizationDto?> Handle(UpdateSalesOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<SalesOrganizationDto>(entity);
    }
}