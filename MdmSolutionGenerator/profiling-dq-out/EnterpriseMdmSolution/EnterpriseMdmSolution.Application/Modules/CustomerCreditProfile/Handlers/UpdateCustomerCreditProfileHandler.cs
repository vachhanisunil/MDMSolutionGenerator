using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerCreditProfile;

namespace EnterpriseMdmSolution.Application.Modules.CustomerCreditProfile.Handlers;

public sealed class UpdateCustomerCreditProfileHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerCreditProfileCommand, CustomerCreditProfileDto?>
{
    public async Task<CustomerCreditProfileDto?> Handle(UpdateCustomerCreditProfileCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerCreditProfileDto>(entity);
    }
}