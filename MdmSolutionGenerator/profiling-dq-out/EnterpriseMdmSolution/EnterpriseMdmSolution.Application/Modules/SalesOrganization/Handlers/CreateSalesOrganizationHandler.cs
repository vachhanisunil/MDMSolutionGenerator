using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class CreateSalesOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateSalesOrganizationCommand, SalesOrganizationDto>
{
    public async Task<SalesOrganizationDto> Handle(CreateSalesOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<SalesOrganizationDto>(entity);
    }
}