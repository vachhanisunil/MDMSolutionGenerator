using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Handlers;

public sealed class GetCustomerCreditProfileByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerCreditProfileByIdQuery, CustomerCreditProfileDto?>
{
    public async Task<CustomerCreditProfileDto?> Handle(GetCustomerCreditProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerCreditProfileDto>(entity);
    }
}