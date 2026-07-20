using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Customer.Commands;
using EnterpriseMdmSolution.Application.Modules.Customer.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Customer;

namespace EnterpriseMdmSolution.Application.Modules.Customer.Handlers;

public sealed class BulkCreateCustomerHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateCustomerCommand, BulkCustomerOperationResultDto>
{
    public async Task<BulkCustomerOperationResultDto> Handle(BulkCreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkCustomerOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<CustomerDto>>(entities)
        };
    }
}