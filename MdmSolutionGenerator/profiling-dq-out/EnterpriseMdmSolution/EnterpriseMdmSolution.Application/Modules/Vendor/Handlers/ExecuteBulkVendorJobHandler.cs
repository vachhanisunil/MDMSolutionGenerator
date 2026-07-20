using System.Text.Json;
using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Vendor.Commands;
using EnterpriseMdmSolution.Application.Modules.Vendor.DTOs;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Vendor;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.Handlers;

public sealed class ExecuteBulkVendorJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository,
    IRepository<Entity> repository,
    IMapper mapper)
    : IRequestHandler<ExecuteBulkVendorJobCommand>
{
    public async Task Handle(ExecuteBulkVendorJobCommand request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Vendor")
        {
            return;
        }

        var items = (await itemRepository.ListAsync(cancellationToken))
            .Where(x => x.JobId == job.JobId)
            .OrderBy(x => x.SequenceNumber)
            .ToList();

        try
        {
            job.Status = "Running";
            job.StartedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(cancellationToken);

            switch (job.Operation)
            {
                case "BulkCreate":
                    await ExecuteCreateAsync(job, items, cancellationToken);
                    break;
                case "BulkUpsert":
                    await ExecuteUpsertAsync(job, items, cancellationToken);
                    break;
                case "BulkDelete":
                    await ExecuteDeleteAsync(job, items, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported bulk operation '{job.Operation}'.");
            }

            job.Status = job.FailedCount == 0 ? "Completed" : "CompletedWithErrors";
            job.CompletedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            job.Status = "Failed";
            job.ErrorMessage = exception.Message;
            job.CompletedOn = DateTimeOffset.UtcNow;
            jobRepository.Update(job);
            await jobRepository.SaveChangesAsync(CancellationToken.None);
        }
    }

    private async Task ExecuteCreateAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var input = JsonSerializer.Deserialize<CreateVendorDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
                var entity = mapper.Map<Entity>(input);
                await repository.AddAsync(entity, cancellationToken);
                await repository.SaveChangesAsync(cancellationToken);
                job.CreatedCount++;
                MarkSucceeded(jobItem, entity);
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private async Task ExecuteUpsertAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var input = JsonSerializer.Deserialize<UpdateVendorDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
                Entity? existingEntity = null;
                if (!EqualityComparer<int>.Default.Equals(input.Id, 0))
                {
                    existingEntity = await repository.GetByIdAsync(input.Id, new[] { "VendorAddresses", "VendorContacts", "VendorBankAccounts", "VendorTaxs", "VendorPurchasingOrganizations", "VendorCompliances", "VendorEvaluations", "VendorCertificates" }, cancellationToken);
                }

                if (existingEntity is null)
                {
                    var newEntity = mapper.Map<Entity>(input);
                foreach (var childItem in input.VendorAddresses)
                {
                    newEntity.VendorAddresses.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorAddress>(childItem));
                }
                foreach (var childItem in input.VendorContacts)
                {
                    newEntity.VendorContacts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorContact>(childItem));
                }
                foreach (var childItem in input.VendorBankAccounts)
                {
                    newEntity.VendorBankAccounts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorBankAccount>(childItem));
                }
                foreach (var childItem in input.VendorTaxs)
                {
                    newEntity.VendorTaxs.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorTax>(childItem));
                }
                foreach (var childItem in input.VendorPurchasingOrganizations)
                {
                    newEntity.VendorPurchasingOrganizations.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorPurchasingOrganization>(childItem));
                }
                foreach (var childItem in input.VendorCompliances)
                {
                    newEntity.VendorCompliances.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCompliance>(childItem));
                }
                foreach (var childItem in input.VendorEvaluations)
                {
                    newEntity.VendorEvaluations.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorEvaluation>(childItem));
                }
                foreach (var childItem in input.VendorCertificates)
                {
                    newEntity.VendorCertificates.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.VendorCertificate>(childItem));
                }
                    await repository.AddAsync(newEntity, cancellationToken);
                    await repository.SaveChangesAsync(cancellationToken);
                    job.CreatedCount++;
                    MarkSucceeded(jobItem, newEntity);
                    continue;
                }

                mapper.Map(input, existingEntity);
        SyncVendorAddresses(existingEntity.VendorAddresses, input.VendorAddresses);

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
        SyncVendorContacts(existingEntity.VendorContacts, input.VendorContacts);

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
        SyncVendorBankAccounts(existingEntity.VendorBankAccounts, input.VendorBankAccounts);

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
        SyncVendorTaxs(existingEntity.VendorTaxs, input.VendorTaxs);

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
        SyncVendorPurchasingOrganizations(existingEntity.VendorPurchasingOrganizations, input.VendorPurchasingOrganizations);

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
        SyncVendorCompliances(existingEntity.VendorCompliances, input.VendorCompliances);

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
        SyncVendorEvaluations(existingEntity.VendorEvaluations, input.VendorEvaluations);

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
        SyncVendorCertificates(existingEntity.VendorCertificates, input.VendorCertificates);

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
                await repository.SaveChangesAsync(cancellationToken);
                job.UpdatedCount++;
                MarkSucceeded(jobItem, existingEntity);
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private async Task ExecuteDeleteAsync(BulkOperationJob job, IReadOnlyList<BulkOperationItem> jobItems, CancellationToken cancellationToken)
    {
        foreach (var jobItem in jobItems)
        {
            try
            {
                var id = JsonSerializer.Deserialize<int>(jobItem.InputSnapshotJson);
                var entity = await repository.GetByIdAsync(id!, cancellationToken);
                if (entity is null)
                {
                    MarkNotFound(job, jobItem, id.ToString());
                    continue;
                }

                repository.Delete(entity);
                await repository.SaveChangesAsync(cancellationToken);
                job.DeletedCount++;
                jobItem.Status = "Succeeded";
                jobItem.RecordId = id.ToString();
            }
            catch (Exception exception)
            {
                MarkFailed(job, jobItem, exception);
            }
        }
    }

    private void MarkSucceeded(BulkOperationItem jobItem, Entity entity)
    {
        jobItem.Status = "Succeeded";
        jobItem.RecordId = entity.Id.ToString();
        jobItem.ResultSnapshotJson = JsonSerializer.Serialize(mapper.Map<VendorDto>(entity));
        itemRepository.Update(jobItem);
    }

    private static void MarkNotFound(BulkOperationJob job, BulkOperationItem jobItem, string? recordId)
    {
        job.FailedCount++;
        jobItem.Status = "NotFound";
        jobItem.RecordId = recordId;
        jobItem.ErrorMessage = "Record was not found.";
    }

    private static void MarkFailed(BulkOperationJob job, BulkOperationItem jobItem, Exception exception)
    {
        job.FailedCount++;
        jobItem.Status = "Failed";
        jobItem.ErrorMessage = exception.Message;
    }
}