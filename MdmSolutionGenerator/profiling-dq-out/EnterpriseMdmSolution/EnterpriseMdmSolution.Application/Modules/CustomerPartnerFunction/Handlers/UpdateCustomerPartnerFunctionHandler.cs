using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Handlers;

public sealed class UpdateCustomerPartnerFunctionHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerPartnerFunctionCommand, CustomerPartnerFunctionDto?>
{
    public async Task<CustomerPartnerFunctionDto?> Handle(UpdateCustomerPartnerFunctionCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerPartnerFunctionDto>(entity);
    }
}