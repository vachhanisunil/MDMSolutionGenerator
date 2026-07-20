using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.Commands;
using EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.SalesOrganization;

namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.Handlers;

public sealed class BulkCreateSalesOrganizationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateSalesOrganizationCommand, BulkSalesOrganizationOperationResultDto>
{
    public async Task<BulkSalesOrganizationOperationResultDto> Handle(BulkCreateSalesOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkSalesOrganizationOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<SalesOrganizationDto>>(entities)
        };
    }
}