using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerSalesArea;

namespace EnterpriseMdmSolution.Application.Modules.CustomerSalesArea.Handlers;

public sealed class UpdateCustomerSalesAreaHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerSalesAreaCommand, CustomerSalesAreaDto?>
{
    public async Task<CustomerSalesAreaDto?> Handle(UpdateCustomerSalesAreaCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerSalesAreaDto>(entity);
    }
}