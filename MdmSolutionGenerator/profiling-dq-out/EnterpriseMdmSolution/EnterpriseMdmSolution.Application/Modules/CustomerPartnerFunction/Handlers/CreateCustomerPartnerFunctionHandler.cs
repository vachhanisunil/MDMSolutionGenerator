using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Handlers;

public sealed class CreateCustomerPartnerFunctionHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerPartnerFunctionCommand, CustomerPartnerFunctionDto>
{
    public async Task<CustomerPartnerFunctionDto> Handle(CreateCustomerPartnerFunctionCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerPartnerFunctionDto>(entity);
    }
}