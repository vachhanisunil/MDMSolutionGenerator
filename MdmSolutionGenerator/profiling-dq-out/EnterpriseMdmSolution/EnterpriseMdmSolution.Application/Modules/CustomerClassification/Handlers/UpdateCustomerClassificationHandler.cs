using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Handlers;

public sealed class UpdateCustomerClassificationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerClassificationCommand, CustomerClassificationDto?>
{
    public async Task<CustomerClassificationDto?> Handle(UpdateCustomerClassificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerClassificationDto>(entity);
    }
}