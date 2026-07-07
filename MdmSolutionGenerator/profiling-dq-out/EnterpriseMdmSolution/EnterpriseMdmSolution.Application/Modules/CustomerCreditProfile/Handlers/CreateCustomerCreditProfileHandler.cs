using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Handlers;

public sealed class CreateCustomerCreditProfileHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerCreditProfileCommand, CustomerCreditProfileDto>
{
    public async Task<CustomerCreditProfileDto> Handle(CreateCustomerCreditProfileCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerCreditProfileDto>(entity);
    }
}