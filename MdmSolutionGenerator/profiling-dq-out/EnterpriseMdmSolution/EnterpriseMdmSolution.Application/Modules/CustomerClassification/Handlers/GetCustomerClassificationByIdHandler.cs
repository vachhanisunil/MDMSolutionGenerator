using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;
using EnterpriseMdmSolution.Application.Modules.CustomerClassification.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.CustomerClassification;

namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.Handlers;

public sealed class GetCustomerClassificationByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetCustomerClassificationByIdQuery, CustomerClassificationDto?>
{
    public async Task<CustomerClassificationDto?> Handle(GetCustomerClassificationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<CustomerClassificationDto>(entity);
    }
}