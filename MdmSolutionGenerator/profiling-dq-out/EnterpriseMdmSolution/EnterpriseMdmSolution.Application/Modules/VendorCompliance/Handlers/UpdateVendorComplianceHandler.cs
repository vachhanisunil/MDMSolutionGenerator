using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Commands;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Handlers;

public sealed class UpdateVendorComplianceHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorComplianceCommand, VendorComplianceDto?>
{
    public async Task<VendorComplianceDto?> Handle(UpdateVendorComplianceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);

        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorComplianceDto>(entity);
    }
}