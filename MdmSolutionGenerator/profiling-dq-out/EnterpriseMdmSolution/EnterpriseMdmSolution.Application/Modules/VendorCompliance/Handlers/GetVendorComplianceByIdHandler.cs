using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs;
using EnterpriseMdmSolution.Application.Modules.VendorCompliance.Queries;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.VendorCompliance;

namespace EnterpriseMdmSolution.Application.Modules.VendorCompliance.Handlers;

public sealed class GetVendorComplianceByIdHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<GetVendorComplianceByIdQuery, VendorComplianceDto?>
{
    public async Task<VendorComplianceDto?> Handle(GetVendorComplianceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, Array.Empty<string>(), cancellationToken);
        return entity is null ? null : mapper.Map<VendorComplianceDto>(entity);
    }
}