using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Material.DataQuality.Services;

public sealed class MaterialProfiler(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ProfileMaterialRecordsTotalRootObjectsAsync(runId, cancellationToken);
        await ProfileMaterialRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialMaterialNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialMaterialNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialMaterialTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialMaterialGroupIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialBaseUnitOfMeasureIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialGrossWeightBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileMaterialNetWeightBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileMaterialPlantRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialPlantPlantIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialPlantProcurementTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialPriceRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialPriceCurrencyIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialPricePriceTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialPricePriceNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialPricePriceBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileMaterialStorageRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialStorageStorageLocationIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialClassificationRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialVendorRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialVendorVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialUOMRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialUOMUnitOfMeasureIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialQualityInspectionRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialForecastRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialForecastPlantIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialForecastForecastPeriodNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialForecastForecastQuantityNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileMaterialForecastForecastQuantityBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileMaterialBarcodeRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileMaterialBarcodeBarcodeValueNullOrEmptyCountAsync(runId, cancellationToken);
    }

    private async Task ProfileMaterialRecordsTotalRootObjectsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "",
            SummaryCode = "MATERIAL_ROOT_OBJECT_COUNT",
            SummaryType = "TotalRootObjects",
            Label = "Total Material root objects",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIAL_ROOT_OBJECT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "",
            SummaryCode = "MATERIAL_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in Material",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIAL_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialNumber",
            SummaryCode = "MATERIAL_MATERIALNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Material.MaterialNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "MaterialNumber",
            SummaryCode = "MATERIAL_MATERIALNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.MaterialNumber,
            Message = "Material.MaterialNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialName",
            SummaryCode = "MATERIAL_MATERIALNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Material.MaterialName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "MaterialName",
            SummaryCode = "MATERIAL_MATERIALNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.MaterialName,
            Message = "Material.MaterialName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => string.IsNullOrEmpty(x.MaterialType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialType",
            SummaryCode = "MATERIAL_MATERIALTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Material.MaterialType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "MaterialType",
            SummaryCode = "MATERIAL_MATERIALTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.MaterialType,
            Message = "Material.MaterialType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialMaterialGroupIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "MaterialGroupId",
            SummaryCode = "MATERIAL_MATERIALGROUPID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Material.MaterialGroupId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_MATERIALGROUPID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "MaterialGroupId",
            SummaryCode = "MATERIAL_MATERIALGROUPID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.MaterialGroupId.ToString(),
            Message = "Material.MaterialGroupId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialGroupId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialBaseUnitOfMeasureIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "BaseUnitOfMeasureId",
            SummaryCode = "MATERIAL_BASEUNITOFMEASUREID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Material.BaseUnitOfMeasureId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_BASEUNITOFMEASUREID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "BaseUnitOfMeasureId",
            SummaryCode = "MATERIAL_BASEUNITOFMEASUREID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.BaseUnitOfMeasureId.ToString(),
            Message = "Material.BaseUnitOfMeasureId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.BaseUnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialGrossWeightBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => x.GrossWeight < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "GrossWeight",
            SummaryCode = "MATERIAL_GROSSWEIGHT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "Material.GrossWeight below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_GROSSWEIGHT_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "GrossWeight",
            SummaryCode = "MATERIAL_GROSSWEIGHT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.GrossWeight.ToString(),
            Message = "Material.GrossWeight below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.GrossWeight }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialNetWeightBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Materials.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Materials
            .Where(x => x.NetWeight < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            ColumnName = "NetWeight",
            SummaryCode = "MATERIAL_NETWEIGHT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "Material.NetWeight below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIAL_NETWEIGHT_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "Material",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "NetWeight",
            SummaryCode = "MATERIAL_NETWEIGHT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.NetWeight.ToString(),
            Message = "Material.NetWeight below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.NetWeight }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPlantRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            ColumnName = "",
            SummaryCode = "MATERIALPLANT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialPlant",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALPLANT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPlantPlantIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            ColumnName = "PlantId",
            SummaryCode = "MATERIALPLANT_PLANTID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialPlant.PlantId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPLANT_PLANTID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PlantId",
            SummaryCode = "MATERIALPLANT_PLANTID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PlantId.ToString(),
            Message = "MaterialPlant.PlantId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPlantProcurementTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPlants.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPlants
            .Where(x => string.IsNullOrEmpty(x.ProcurementType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            ColumnName = "ProcurementType",
            SummaryCode = "MATERIALPLANT_PROCUREMENTTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialPlant.ProcurementType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPLANT_PROCUREMENTTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPlant",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ProcurementType",
            SummaryCode = "MATERIALPLANT_PROCUREMENTTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ProcurementType,
            Message = "MaterialPlant.ProcurementType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ProcurementType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPriceRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "",
            SummaryCode = "MATERIALPRICE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialPrice",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALPRICE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPriceCurrencyIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "CurrencyId",
            SummaryCode = "MATERIALPRICE_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialPrice.CurrencyId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPRICE_CURRENCYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CurrencyId",
            SummaryCode = "MATERIALPRICE_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CurrencyId.ToString(),
            Message = "MaterialPrice.CurrencyId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPricePriceTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => string.IsNullOrEmpty(x.PriceType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "PriceType",
            SummaryCode = "MATERIALPRICE_PRICETYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialPrice.PriceType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPRICE_PRICETYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PriceType",
            SummaryCode = "MATERIALPRICE_PRICETYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PriceType,
            Message = "MaterialPrice.PriceType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PriceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPricePriceNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "Price",
            SummaryCode = "MATERIALPRICE_PRICE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialPrice.Price missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPRICE_PRICE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Price",
            SummaryCode = "MATERIALPRICE_PRICE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.Price.ToString(),
            Message = "MaterialPrice.Price missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.Price }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialPricePriceBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialPrices.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialPrices
            .Where(x => x.Price < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            ColumnName = "Price",
            SummaryCode = "MATERIALPRICE_PRICE_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "MaterialPrice.Price below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALPRICE_PRICE_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialPrice",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Price",
            SummaryCode = "MATERIALPRICE_PRICE_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.Price.ToString(),
            Message = "MaterialPrice.Price below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.Price }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialStorageRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            ColumnName = "",
            SummaryCode = "MATERIALSTORAGE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialStorage",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALSTORAGE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialStorageStorageLocationIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialStorages.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialStorages
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            ColumnName = "StorageLocationId",
            SummaryCode = "MATERIALSTORAGE_STORAGELOCATIONID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialStorage.StorageLocationId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALSTORAGE_STORAGELOCATIONID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialStorage",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "StorageLocationId",
            SummaryCode = "MATERIALSTORAGE_STORAGELOCATIONID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.StorageLocationId.ToString(),
            Message = "MaterialStorage.StorageLocationId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.StorageLocationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialClassificationRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialClassifications
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialClassification",
            ColumnName = "",
            SummaryCode = "MATERIALCLASSIFICATION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialClassification",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALCLASSIFICATION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialVendorRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            ColumnName = "",
            SummaryCode = "MATERIALVENDOR_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialVendor",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALVENDOR_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialVendorVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialVendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialVendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            ColumnName = "VendorId",
            SummaryCode = "MATERIALVENDOR_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialVendor.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALVENDOR_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialVendor",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "MATERIALVENDOR_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "MaterialVendor.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialUOMRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            ColumnName = "",
            SummaryCode = "MATERIALUOM_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialUOM",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALUOM_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialUOMUnitOfMeasureIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialUOMs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialUOMs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            ColumnName = "UnitOfMeasureId",
            SummaryCode = "MATERIALUOM_UNITOFMEASUREID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialUOM.UnitOfMeasureId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALUOM_UNITOFMEASUREID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialUOM",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "UnitOfMeasureId",
            SummaryCode = "MATERIALUOM_UNITOFMEASUREID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.UnitOfMeasureId.ToString(),
            Message = "MaterialUOM.UnitOfMeasureId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.UnitOfMeasureId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialQualityInspectionRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialQualityInspections.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialQualityInspections
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialQualityInspection",
            ColumnName = "",
            SummaryCode = "MATERIALQUALITYINSPECTION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialQualityInspection",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALQUALITYINSPECTION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "",
            SummaryCode = "MATERIALFORECAST_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialForecast",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALFORECAST_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastPlantIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "PlantId",
            SummaryCode = "MATERIALFORECAST_PLANTID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialForecast.PlantId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALFORECAST_PLANTID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PlantId",
            SummaryCode = "MATERIALFORECAST_PLANTID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PlantId.ToString(),
            Message = "MaterialForecast.PlantId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.PlantId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastForecastPeriodNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => string.IsNullOrEmpty(x.ForecastPeriod))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "ForecastPeriod",
            SummaryCode = "MATERIALFORECAST_FORECASTPERIOD_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialForecast.ForecastPeriod missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALFORECAST_FORECASTPERIOD_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ForecastPeriod",
            SummaryCode = "MATERIALFORECAST_FORECASTPERIOD_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ForecastPeriod,
            Message = "MaterialForecast.ForecastPeriod missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastPeriod }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastForecastQuantityNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "ForecastQuantity",
            SummaryCode = "MATERIALFORECAST_FORECASTQUANTITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialForecast.ForecastQuantity missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALFORECAST_FORECASTQUANTITY_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ForecastQuantity",
            SummaryCode = "MATERIALFORECAST_FORECASTQUANTITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ForecastQuantity.ToString(),
            Message = "MaterialForecast.ForecastQuantity missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastQuantity }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialForecastForecastQuantityBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialForecasts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialForecasts
            .Where(x => x.ForecastQuantity < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            ColumnName = "ForecastQuantity",
            SummaryCode = "MATERIALFORECAST_FORECASTQUANTITY_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "MaterialForecast.ForecastQuantity below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALFORECAST_FORECASTQUANTITY_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialForecast",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ForecastQuantity",
            SummaryCode = "MATERIALFORECAST_FORECASTQUANTITY_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.ForecastQuantity.ToString(),
            Message = "MaterialForecast.ForecastQuantity below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.ForecastQuantity }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialBarcodeRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            ColumnName = "",
            SummaryCode = "MATERIALBARCODE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in MaterialBarcode",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "MATERIALBARCODE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileMaterialBarcodeBarcodeValueNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.MaterialBarcodes.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.MaterialBarcodes
            .Where(x => string.IsNullOrEmpty(x.BarcodeValue))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            ColumnName = "BarcodeValue",
            SummaryCode = "MATERIALBARCODE_BARCODEVALUE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "MaterialBarcode.BarcodeValue missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "MATERIALBARCODE_BARCODEVALUE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Material",
            EntityName = "MaterialBarcode",
            RootRecordId = x.MaterialId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "BarcodeValue",
            SummaryCode = "MATERIALBARCODE_BARCODEVALUE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.BarcodeValue,
            Message = "MaterialBarcode.BarcodeValue missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.MaterialId, x.BarcodeValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
