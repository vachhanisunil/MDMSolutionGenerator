using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class BulkUpdateVendorHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpdateVendorCommand, BulkVendorOperationResultDto>
{
    public async Task<BulkVendorOperationResultDto> Handle(BulkUpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var updatedEntities = new List<Entity>();
        var notFoundIds = new List<int>();

        foreach (var requestedItem in request.Input.Items)
        {
            var existingEntity = await repository.GetByIdAsync(requestedItem.Id, new[] { "VendorAddresses", "VendorContacts", "VendorBankAccounts", "VendorTaxs", "VendorPurchasingOrganizations", "VendorCompliances", "VendorEvaluations", "VendorCertificates" }, cancellationToken);
            if (existingEntity is null)
            {
                notFoundIds.Add(requestedItem.Id);
                continue;
            }

            mapper.Map(requestedItem, existingEntity);
        SyncVendorAddresses(existingEntity.VendorAddresses, requestedItem.VendorAddresses);

        void SyncVendorAddresses(ICollection<EnterpriseMdmSolution.Core.Entities.VendorAddress> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs.UpdateVendorAddressDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorAddress>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorAddress>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorContacts(existingEntity.VendorContacts, requestedItem.VendorContacts);

        void SyncVendorContacts(ICollection<EnterpriseMdmSolution.Core.Entities.VendorContact> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorContact.DTOs.UpdateVendorContactDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorContact>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorContact>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorBankAccounts(existingEntity.VendorBankAccounts, requestedItem.VendorBankAccounts);

        void SyncVendorBankAccounts(ICollection<EnterpriseMdmSolution.Core.Entities.VendorBankAccount> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorBankAccount.DTOs.UpdateVendorBankAccountDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorBankAccount>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorBankAccount>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorTaxs(existingEntity.VendorTaxs, requestedItem.VendorTaxs);

        void SyncVendorTaxs(ICollection<EnterpriseMdmSolution.Core.Entities.VendorTax> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs.UpdateVendorTaxDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorTax>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorTax>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorPurchasingOrganizations(existingEntity.VendorPurchasingOrganizations, requestedItem.VendorPurchasingOrganizations);

        void SyncVendorPurchasingOrganizations(ICollection<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorPurchasingOrganization.DTOs.UpdateVendorPurchasingOrganizationDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorCompliances(existingEntity.VendorCompliances, requestedItem.VendorCompliances);

        void SyncVendorCompliances(ICollection<EnterpriseMdmSolution.Core.Entities.VendorCompliance> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorCompliance.DTOs.UpdateVendorComplianceDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCompliance>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCompliance>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorEvaluations(existingEntity.VendorEvaluations, requestedItem.VendorEvaluations);

        void SyncVendorEvaluations(ICollection<EnterpriseMdmSolution.Core.Entities.VendorEvaluation> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorEvaluation.DTOs.UpdateVendorEvaluationDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorEvaluation>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorEvaluation>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncVendorCertificates(existingEntity.VendorCertificates, requestedItem.VendorCertificates);

        void SyncVendorCertificates(ICollection<EnterpriseMdmSolution.Core.Entities.VendorCertificate> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.VendorCertificate.DTOs.UpdateVendorCertificateDto> requestedItems)
        {
            var requestedList = requestedItems.ToList();
            var requestedExistingIds = requestedList.Where(item => !EqualityComparer<int>.Default.Equals(item.Id, 0)).Select(item => item.Id).ToHashSet();
            var itemsToRemove = existingItems.Where(item => !requestedExistingIds.Contains(item.Id)).ToList();
            foreach (var item in itemsToRemove)
            {
                existingItems.Remove(item);
            }

            foreach (var requestedItem in requestedList)
            {
                if (EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCertificate>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCertificate>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
            repository.Update(existingEntity);
            updatedEntities.Add(existingEntity);
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkVendorOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            UpdatedCount = updatedEntities.Count,
            NotFoundIds = notFoundIds,
            Items = mapper.Map<IReadOnlyList<VendorDto>>(updatedEntities)
        };
    }
}