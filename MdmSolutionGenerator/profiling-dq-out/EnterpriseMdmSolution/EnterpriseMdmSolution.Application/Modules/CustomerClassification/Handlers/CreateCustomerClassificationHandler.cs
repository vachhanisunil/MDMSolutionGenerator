using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Commands;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Handlers;

public sealed class CreateCustomerClassificationHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateCustomerClassificationCommand, CustomerClassificationDto>
{
    public async Task<CustomerClassificationDto> Handle(CreateCustomerClassificationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<CustomerClassificationDto>(entity);
    }
}