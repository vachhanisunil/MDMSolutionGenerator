using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class UpdateVendorHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<UpdateVendorCommand, VendorDto?>
{
    public async Task<VendorDto?> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, new[] { "VendorAddresses", "VendorContacts", "VendorBankAccounts", "VendorTaxs", "VendorPurchasingOrganizations", "VendorCompliances", "VendorEvaluations", "VendorCertificates" }, cancellationToken);
        if (entity is null)
        {
            return null;
        }

        mapper.Map(request.Input, entity);
        repository.ReplaceCollection(entity.VendorAddresses, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorAddress>>(request.Input.VendorAddresses));
        repository.ReplaceCollection(entity.VendorContacts, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorContact>>(request.Input.VendorContacts));
        repository.ReplaceCollection(entity.VendorBankAccounts, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorBankAccount>>(request.Input.VendorBankAccounts));
        repository.ReplaceCollection(entity.VendorTaxs, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorTax>>(request.Input.VendorTaxs));
        repository.ReplaceCollection(entity.VendorPurchasingOrganizations, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization>>(request.Input.VendorPurchasingOrganizations));
        repository.ReplaceCollection(entity.VendorCompliances, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorCompliance>>(request.Input.VendorCompliances));
        repository.ReplaceCollection(entity.VendorEvaluations, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorEvaluation>>(request.Input.VendorEvaluations));
        repository.ReplaceCollection(entity.VendorCertificates, mapper.Map<List<EnterpriseMdmSolution.Core.Entities.VendorCertificate>>(request.Input.VendorCertificates));
        repository.Update(entity);
        await repository.SaveChangesAsync(cancellationToken);
        return mapper.Map<VendorDto>(entity);
    }
}