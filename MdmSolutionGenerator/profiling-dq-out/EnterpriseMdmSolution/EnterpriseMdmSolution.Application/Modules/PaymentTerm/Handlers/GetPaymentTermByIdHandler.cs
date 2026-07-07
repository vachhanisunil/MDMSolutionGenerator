using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class GetPaymentTermByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetPaymentTermByIdQuery, PaymentTermDto?>
{
    public async Task<PaymentTermDto?> Handle(GetPaymentTermByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<PaymentTermDto>(entity);
    }
}