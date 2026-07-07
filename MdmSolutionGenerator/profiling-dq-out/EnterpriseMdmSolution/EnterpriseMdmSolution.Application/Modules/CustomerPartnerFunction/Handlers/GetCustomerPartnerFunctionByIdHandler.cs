using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerPartnerFunction;

namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.Handlers;

public sealed class GetCustomerPartnerFunctionByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerPartnerFunctionByIdQuery, CustomerPartnerFunctionDto?>
{
    public async Task<CustomerPartnerFunctionDto?> Handle(GetCustomerPartnerFunctionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerPartnerFunctionDto>(entity);
    }
}