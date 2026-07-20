using System.Text.Json;
using AutoMapper;
using MediatR;
using EnterpriseMdmSolution.Application.Modules.Material.Commands;
using EnterpriseMdmSolution.Application.Modules.Material.DTOs;
using EnterpriseMdmSolution.Core.DataQuality;
using EnterpriseMdmSolution.Core.Interfaces;
using Entity = EnterpriseMdmSolution.Core.Entities.Material;

namespace EnterpriseMdmSolution.Application.Modules.Material.Handlers;

public sealed class ExecuteBulkMaterialJobHandler(
    IRepository<BulkOperationJob> jobRepository,
    IRepository<BulkOperationItem> itemRepository,
    IRepository<Entity> repository,
    IMapper mapper)
    : IRequestHandler<ExecuteBulkMaterialJobCommand>
{
    public async Task Handle(ExecuteBulkMaterialJobCommand request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null || job.BusinessObjectName != "Material")
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
                var input = JsonSerializer.Deserialize<CreateMaterialDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
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
                var input = JsonSerializer.Deserialize<UpdateMaterialDto>(jobItem.InputSnapshotJson) ?? throw new InvalidOperationException("Bulk item payload is invalid.");
                Entity? existingEntity = null;
                if (!EqualityComparer<int>.Default.Equals(input.Id, 0))
                {
                    existingEntity = await repository.GetByIdAsync(input.Id, new[] { "MaterialPlants", "MaterialPrices", "MaterialStorages", "MaterialClassifications", "MaterialVendors", "MaterialUOMs", "MaterialQualityInspections", "MaterialForecasts", "MaterialBarcodes" }, cancellationToken);
                }

                if (existingEntity is null)
                {
                    var newEntity = mapper.Map<Entity>(input);
                foreach (var childItem in input.MaterialPlants)
                {
                    newEntity.MaterialPlants.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(childItem));
                }
                foreach (var childItem in input.MaterialPrices)
                {
                    newEntity.MaterialPrices.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(childItem));
                }
                foreach (var childItem in input.MaterialStorages)
                {
                    newEntity.MaterialStorages.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(childItem));
                }
                foreach (var childItem in input.MaterialClassifications)
                {
                    newEntity.MaterialClassifications.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(childItem));
                }
                foreach (var childItem in input.MaterialVendors)
                {
                    newEntity.MaterialVendors.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(childItem));
                }
                foreach (var childItem in input.MaterialUOMs)
                {
                    newEntity.MaterialUOMs.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(childItem));
                }
                foreach (var childItem in input.MaterialQualityInspections)
                {
                    newEntity.MaterialQualityInspections.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(childItem));
                }
                foreach (var childItem in input.MaterialForecasts)
                {
                    newEntity.MaterialForecasts.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(childItem));
                }
                foreach (var childItem in input.MaterialBarcodes)
                {
                    newEntity.MaterialBarcodes.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(childItem));
                }
                    await repository.AddAsync(newEntity, cancellationToken);
                    await repository.SaveChangesAsync(cancellationToken);
                    job.CreatedCount++;
                    MarkSucceeded(jobItem, newEntity);
                    continue;
                }

                mapper.Map(input, existingEntity);
        SyncMaterialPlants(existingEntity.MaterialPlants, input.MaterialPlants);

        void SyncMaterialPlants(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialPlant> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs.UpdateMaterialPlantDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPlant>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialPrices(existingEntity.MaterialPrices, input.MaterialPrices);

        void SyncMaterialPrices(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialPrice> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs.UpdateMaterialPriceDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialPrice>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialStorages(existingEntity.MaterialStorages, input.MaterialStorages);

        void SyncMaterialStorages(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialStorage> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialStorage.DTOs.UpdateMaterialStorageDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialStorage>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialClassifications(existingEntity.MaterialClassifications, input.MaterialClassifications);

        void SyncMaterialClassifications(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialClassification> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs.UpdateMaterialClassificationDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialClassification>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialVendors(existingEntity.MaterialVendors, input.MaterialVendors);

        void SyncMaterialVendors(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialVendor> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialVendor.DTOs.UpdateMaterialVendorDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialVendor>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialUOMs(existingEntity.MaterialUOMs, input.MaterialUOMs);

        void SyncMaterialUOMs(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialUOM> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs.UpdateMaterialUOMDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialUOM>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialQualityInspections(existingEntity.MaterialQualityInspections, input.MaterialQualityInspections);

        void SyncMaterialQualityInspections(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialQualityInspection.DTOs.UpdateMaterialQualityInspectionDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialQualityInspection>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialForecasts(existingEntity.MaterialForecasts, input.MaterialForecasts);

        void SyncMaterialForecasts(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialForecast> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs.UpdateMaterialForecastDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialForecast>(requestedItem));
                    continue;
                }

                mapper.Map(requestedItem, existingItem);
            }
        }
        SyncMaterialBarcodes(existingEntity.MaterialBarcodes, input.MaterialBarcodes);

        void SyncMaterialBarcodes(ICollection<EnterpriseMdmSolution.Core.Entities.MaterialBarcode> existingItems, IEnumerable<EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs.UpdateMaterialBarcodeDto> requestedItems)
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
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(requestedItem));
                    continue;
                }

                var existingItem = existingItems.FirstOrDefault(item => EqualityComparer<int>.Default.Equals(item.Id, requestedItem.Id));
                if (existingItem is null)
                {
                    existingItems.Add(mapper.Map<EnterpriseMdmSolution.Core.Entities.MaterialBarcode>(requestedItem));
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
        jobItem.ResultSnapshotJson = JsonSerializer.Serialize(mapper.Map<MaterialDto>(entity));
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