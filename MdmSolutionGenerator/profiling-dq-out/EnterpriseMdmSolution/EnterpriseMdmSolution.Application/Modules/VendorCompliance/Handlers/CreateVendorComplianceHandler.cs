using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Handlers;

public sealed class CreateVendorComplianceHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<CreateVendorComplianceCommand, VendorComplianceDto>
{
    public async Task<VendorComplianceDto> Handle(CreateVendorComplianceCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entity>(request.Input);
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorComplianceDto>(entity);
    }
}