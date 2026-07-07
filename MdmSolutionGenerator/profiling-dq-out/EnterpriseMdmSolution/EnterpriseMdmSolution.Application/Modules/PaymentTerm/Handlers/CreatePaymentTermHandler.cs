using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.Commands;
using EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.PaymentTerm;

namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.Handlers;

public sealed class CreatePaymentTermHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreatePaymentTermCommand, PaymentTermDto>
{
    public async Task<PaymentTermDto> Handle(CreatePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<PaymentTermDto>(entity);
    }
}