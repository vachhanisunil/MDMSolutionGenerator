using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class BulkUpsertVendorHandler(IRepository<Entity> repository, IMapper mapper)
    : IRequestHandler<BulkUpsertVendorCommand, BulkVendorOperationResultDto>
{
    public async Task<BulkVendorOperationResultDto> Handle(BulkUpsertVendorCommand request, CancellationToken cancellationToken)
    {
        var changedEntities = new List<Entity>();
        var createdCount = 0;
        var updatedCount = 0;

        foreach (var requestedItem in request.Input.Items)
        {
            Entity? existingEntity = null;
            if (!EqualityComparer<int>.Default.Equals(requestedItem.Id, 0))
            {
                existingEntity = await repository.GetByIdAsync(requestedItem.Id, new[] { "VendorAddresses", "VendorContacts", "VendorBankAccounts", "VendorTaxs", "VendorPurchasingOrganizations", "VendorCompliances", "VendorEvaluations", "VendorCertificates" }, cancellationToken);
            }

            if (existingEntity is null)
            {
                var newEntity = mapper.Map<Entity>(requestedItem);
                foreach (var childItem in requestedItem.VendorAddresses)
                {
                    newEntity.VendorAddresses.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorAddress>(childItem));
                }
                foreach (var childItem in requestedItem.VendorContacts)
                {
                    newEntity.VendorContacts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorContact>(childItem));
                }
                foreach (var childItem in requestedItem.VendorBankAccounts)
                {
                    newEntity.VendorBankAccounts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorBankAccount>(childItem));
                }
                foreach (var childItem in requestedItem.VendorTaxs)
                {
                    newEntity.VendorTaxs.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorTax>(childItem));
                }
                foreach (var childItem in requestedItem.VendorPurchasingOrganizations)
                {
                    newEntity.VendorPurchasingOrganizations.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization>(childItem));
                }
                foreach (var childItem in requestedItem.VendorCompliances)
                {
                    newEntity.VendorCompliances.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCompliance>(childItem));
                }
                foreach (var childItem in requestedItem.VendorEvaluations)
                {
                    newEntity.VendorEvaluations.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorEvaluation>(childItem));
                }
                foreach (var childItem in requestedItem.VendorCertificates)
                {
                    newEntity.VendorCertificates.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCertificate>(childItem));
                }
                await repository.AddAsync(newEntity, cancellationToken);
                changedEntities.Add(newEntity);
                createdCount++;
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
            changedEntities.Add(existingEntity);
            updatedCount++;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return new BulkVendorOperationResultDto
        {
            RequestedCount = request.Input.Items.Count,
            CreatedCount = createdCount,
            UpdatedCount = updatedCount,
            Items = mapper.Map<IReadOnlyList<VendorDto>>(changedEntities)
        };
    }
}