using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class BulkCreateVendorHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkCreateVendorCommand, BulkVendorOperationResultDto>
{
    public async Task<BulkVendorOperationResultDto> Handle(BulkCreateVendorCommand request, CancellationToken cancellationToken)
    {
        var entities = request.Input.Items.Select(mapper.Map<Entity>).ToList();
        foreach (var entity in entities)
        {
            await repository.AddAsync(entity, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkVendorOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = entities.Count,
            Items = mapper.Map<IReadOnlyList<VendorDto>>(entities)
        };
    }
}