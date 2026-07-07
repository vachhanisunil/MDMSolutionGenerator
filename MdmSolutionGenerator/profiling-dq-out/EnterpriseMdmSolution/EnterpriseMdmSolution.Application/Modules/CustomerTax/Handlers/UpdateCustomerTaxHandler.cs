using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerTax;

namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.Handlers;

public sealed class UpdateCustomerTaxHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerTaxCommand, CustomerTaxDto?>
{
    public async Task<CustomerTaxDto?> Handle(UpdateCustomerTaxCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerTaxDto>(entity);
    }
}