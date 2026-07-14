using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services;

public sealed class VendorProfiler(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ProfileVendorRecordsTotalRootObjectsAsync(runId, cancellationToken);
        await ProfileVendorRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorVendorNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorVendorNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorVendorTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorEmailInvalidFormatCountAsync(runId, cancellationToken);
        await ProfileVendorCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorCurrencyIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorAddressVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressAddressTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressAddressLine1NullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressCityNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressPostalCodeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorAddressCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorContactRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorContactVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorContactFirstNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorContactLastNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorContactEmailInvalidFormatCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorBankAccountVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountBankNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountAccountNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountCurrencyIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorTaxRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorTaxVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorTaxTaxTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorTaxTaxNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorTaxCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorPurchasingOrganizationRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorPurchasingOrganizationVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorPurchasingOrganizationPurchasingOrganizationIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorComplianceRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorComplianceVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorComplianceComplianceTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorEvaluationRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorEvaluationVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorCertificateRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileVendorCertificateVendorIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileVendorVendorTypeDistinctCountAsync(runId, cancellationToken);
        await ProfileVendorSupplierCategoryDistinctCountAsync(runId, cancellationToken);
        await ProfileVendorOnboardingStatusDistinctCountAsync(runId, cancellationToken);
        await ProfileVendorEmailDuplicateCountAsync(runId, cancellationToken);
        await ProfileVendorDunsNumberDuplicateCountAsync(runId, cancellationToken);
        await ProfileVendorAddressCityDistinctCountAsync(runId, cancellationToken);
        await ProfileVendorContactEmailDuplicateCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountAccountNumberDuplicateCountAsync(runId, cancellationToken);
        await ProfileVendorPurchasingOrganizationMinimumOrderValueAverageValueAsync(runId, cancellationToken);
        await ProfileVendorEvaluationOverallScoreAverageValueAsync(runId, cancellationToken);
        await ProfileVendorEvaluationQualityScoreMinValueAsync(runId, cancellationToken);
        await ProfileVendorCertificateCertificateTypeDistinctCountAsync(runId, cancellationToken);
    }

    private async Task ProfileVendorRecordsTotalRootObjectsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "",
            SummaryCode = "VENDOR_ROOT_OBJECT_COUNT",
            SummaryType = "TotalRootObjects",
            Label = "Total Vendor root objects",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDOR_ROOT_OBJECT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "",
            SummaryCode = "VENDOR_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in Vendor",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDOR_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "VendorNumber",
            SummaryCode = "VENDOR_VENDORNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Vendor.VendorNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorNumber",
            SummaryCode = "VENDOR_VENDORNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorNumber,
            Message = "Vendor.VendorNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "VendorName",
            SummaryCode = "VENDOR_VENDORNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Vendor.VendorName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorName",
            SummaryCode = "VENDOR_VENDORNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorName,
            Message = "Vendor.VendorName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "VendorType",
            SummaryCode = "VENDOR_VENDORTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Vendor.VendorType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorType",
            SummaryCode = "VENDOR_VENDORTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorType,
            Message = "Vendor.VendorType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEmailInvalidFormatCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => x.Email != null && !x.Email.Contains("@"))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "Email",
            SummaryCode = "VENDOR_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            Label = "Invalid email format in Vendor.Email",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_EMAIL_INVALID_EMAIL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "VENDOR_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            FieldValue = x.Email,
            Message = "Invalid email format in Vendor.Email",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "CountryId",
            SummaryCode = "VENDOR_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Vendor.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "VENDOR_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "Vendor.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCurrencyIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "CurrencyId",
            SummaryCode = "VENDOR_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Vendor.CurrencyId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_CURRENCYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CurrencyId",
            SummaryCode = "VENDOR_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CurrencyId.ToString(),
            Message = "Vendor.CurrencyId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "",
            SummaryCode = "VENDORADDRESS_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorAddress",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORADDRESS_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "VendorId",
            SummaryCode = "VENDORADDRESS_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORADDRESS_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorAddress.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressAddressTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "AddressType",
            SummaryCode = "VENDORADDRESS_ADDRESSTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.AddressType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_ADDRESSTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AddressType",
            SummaryCode = "VENDORADDRESS_ADDRESSTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AddressType,
            Message = "VendorAddress.AddressType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressAddressLine1NullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "AddressLine1",
            SummaryCode = "VENDORADDRESS_ADDRESSLINE1_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.AddressLine1 missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_ADDRESSLINE1_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AddressLine1",
            SummaryCode = "VENDORADDRESS_ADDRESSLINE1_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AddressLine1,
            Message = "VendorAddress.AddressLine1 missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressCityNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "City",
            SummaryCode = "VENDORADDRESS_CITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.City missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_CITY_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "City",
            SummaryCode = "VENDORADDRESS_CITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.City,
            Message = "VendorAddress.City missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressPostalCodeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "PostalCode",
            SummaryCode = "VENDORADDRESS_POSTALCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.PostalCode missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_POSTALCODE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PostalCode",
            SummaryCode = "VENDORADDRESS_POSTALCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PostalCode,
            Message = "VendorAddress.PostalCode missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "CountryId",
            SummaryCode = "VENDORADDRESS_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorAddress.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORADDRESS_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "VENDORADDRESS_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "VendorAddress.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "",
            SummaryCode = "VENDORCONTACT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorContact",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORCONTACT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "VendorId",
            SummaryCode = "VENDORCONTACT_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorContact.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCONTACT_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORCONTACT_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorContact.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactFirstNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "FirstName",
            SummaryCode = "VENDORCONTACT_FIRSTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorContact.FirstName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCONTACT_FIRSTNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "FirstName",
            SummaryCode = "VENDORCONTACT_FIRSTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.FirstName,
            Message = "VendorContact.FirstName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactLastNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "LastName",
            SummaryCode = "VENDORCONTACT_LASTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorContact.LastName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCONTACT_LASTNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "LastName",
            SummaryCode = "VENDORCONTACT_LASTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.LastName,
            Message = "VendorContact.LastName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactEmailInvalidFormatCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => x.Email != null && !x.Email.Contains("@"))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "Email",
            SummaryCode = "VENDORCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            Label = "Invalid email format in VendorContact.Email",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "VENDORCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            FieldValue = x.Email,
            Message = "Invalid email format in VendorContact.Email",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "",
            SummaryCode = "VENDORBANKACCOUNT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorBankAccount",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORBANKACCOUNT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "VendorId",
            SummaryCode = "VENDORBANKACCOUNT_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorBankAccount.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORBANKACCOUNT_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORBANKACCOUNT_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorBankAccount.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountBankNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "BankName",
            SummaryCode = "VENDORBANKACCOUNT_BANKNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorBankAccount.BankName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORBANKACCOUNT_BANKNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "BankName",
            SummaryCode = "VENDORBANKACCOUNT_BANKNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.BankName,
            Message = "VendorBankAccount.BankName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountAccountNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "AccountNumber",
            SummaryCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorBankAccount.AccountNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AccountNumber",
            SummaryCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AccountNumber,
            Message = "VendorBankAccount.AccountNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountCurrencyIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "CurrencyId",
            SummaryCode = "VENDORBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorBankAccount.CurrencyId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CurrencyId",
            SummaryCode = "VENDORBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CurrencyId.ToString(),
            Message = "VendorBankAccount.CurrencyId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            ColumnName = "",
            SummaryCode = "VENDORTAX_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorTax",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORTAX_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            ColumnName = "VendorId",
            SummaryCode = "VENDORTAX_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorTax.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORTAX_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORTAX_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorTax.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxTaxTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            ColumnName = "TaxType",
            SummaryCode = "VENDORTAX_TAXTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorTax.TaxType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORTAX_TAXTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "TaxType",
            SummaryCode = "VENDORTAX_TAXTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.TaxType,
            Message = "VendorTax.TaxType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxTaxNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            ColumnName = "TaxNumber",
            SummaryCode = "VENDORTAX_TAXNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorTax.TaxNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORTAX_TAXNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "TaxNumber",
            SummaryCode = "VENDORTAX_TAXNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.TaxNumber,
            Message = "VendorTax.TaxNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            ColumnName = "CountryId",
            SummaryCode = "VENDORTAX_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorTax.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORTAX_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "VENDORTAX_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "VendorTax.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorPurchasingOrganizationRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            ColumnName = "",
            SummaryCode = "VENDORPURCHASINGORGANIZATION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorPurchasingOrganization",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORPURCHASINGORGANIZATION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorPurchasingOrganizationVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            ColumnName = "VendorId",
            SummaryCode = "VENDORPURCHASINGORGANIZATION_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorPurchasingOrganization.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORPURCHASINGORGANIZATION_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORPURCHASINGORGANIZATION_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorPurchasingOrganization.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorPurchasingOrganizationPurchasingOrganizationIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            ColumnName = "PurchasingOrganizationId",
            SummaryCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorPurchasingOrganization.PurchasingOrganizationId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PurchasingOrganizationId",
            SummaryCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PurchasingOrganizationId.ToString(),
            Message = "VendorPurchasingOrganization.PurchasingOrganizationId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchasingOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorComplianceRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            ColumnName = "",
            SummaryCode = "VENDORCOMPLIANCE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorCompliance",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORCOMPLIANCE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorComplianceVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            ColumnName = "VendorId",
            SummaryCode = "VENDORCOMPLIANCE_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorCompliance.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCOMPLIANCE_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORCOMPLIANCE_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorCompliance.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorComplianceComplianceTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            ColumnName = "ComplianceType",
            SummaryCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorCompliance.ComplianceType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCOMPLIANCE_COMPLIANCETYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ComplianceType",
            SummaryCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ComplianceType,
            Message = "VendorCompliance.ComplianceType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEvaluationRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            ColumnName = "",
            SummaryCode = "VENDOREVALUATION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorEvaluation",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDOREVALUATION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEvaluationVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            ColumnName = "VendorId",
            SummaryCode = "VENDOREVALUATION_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorEvaluation.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOREVALUATION_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDOREVALUATION_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorEvaluation.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCertificateRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            ColumnName = "",
            SummaryCode = "VENDORCERTIFICATE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in VendorCertificate",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "VENDORCERTIFICATE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCertificateVendorIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            ColumnName = "VendorId",
            SummaryCode = "VENDORCERTIFICATE_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "VendorCertificate.VendorId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCERTIFICATE_VENDORID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "VendorId",
            SummaryCode = "VENDORCERTIFICATE_VENDORID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.VendorId.ToString(),
            Message = "VendorCertificate.VendorId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorTypeDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.Vendors
            .Select(x => x.VendorType)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "VendorType",
            SummaryCode = "VENDOR_VENDORTYPE_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct vendor types",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "VENDOR_VENDORTYPE_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorSupplierCategoryDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.Vendors
            .Select(x => x.SupplierCategory)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "SupplierCategory",
            SummaryCode = "VENDOR_SUPPLIERCATEGORY_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct supplier categories",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "VENDOR_SUPPLIERCATEGORY_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorOnboardingStatusDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.Vendors
            .Select(x => x.OnboardingStatus)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "OnboardingStatus",
            SummaryCode = "VENDOR_ONBOARDINGSTATUS_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct vendor onboarding statuses",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "VENDOR_ONBOARDINGSTATUS_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEmailDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.Vendors
            .Where(x => x.Email != null && x.Email != "")
            .GroupBy(x => x.Email)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => duplicateValues.Contains(x.Email))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "Email",
            SummaryCode = "VENDOR_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate vendor email records",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_EMAIL_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "VENDOR_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.Email,
            Message = "Duplicate vendor email records",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorDunsNumberDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.Vendors
            .Where(x => x.DunsNumber != null && x.DunsNumber != "")
            .GroupBy(x => x.DunsNumber)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.Vendors
            .Where(x => duplicateValues.Contains(x.DunsNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            ColumnName = "DunsNumber",
            SummaryCode = "VENDOR_DUNSNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate vendor DUNS numbers",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_DUNSNUMBER_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "DunsNumber",
            SummaryCode = "VENDOR_DUNSNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.DunsNumber,
            Message = "Duplicate vendor DUNS numbers",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.DunsNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressCityDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.VendorAddresses
            .Select(x => x.City)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            ColumnName = "City",
            SummaryCode = "VENDORADDRESS_CITY_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct vendor address cities",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "VENDORADDRESS_CITY_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactEmailDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.VendorContacts
            .Where(x => x.Email != null && x.Email != "")
            .GroupBy(x => x.Email)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.VendorContacts
            .Where(x => duplicateValues.Contains(x.Email))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            ColumnName = "Email",
            SummaryCode = "VENDORCONTACT_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate vendor contact email records",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORCONTACT_EMAIL_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "VENDORCONTACT_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.Email,
            Message = "Duplicate vendor contact email records",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountAccountNumberDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.VendorBankAccounts
            .Where(x => x.AccountNumber != null && x.AccountNumber != "")
            .GroupBy(x => x.AccountNumber)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => duplicateValues.Contains(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            ColumnName = "AccountNumber",
            SummaryCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate vendor bank account numbers",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDORBANKACCOUNT_ACCOUNTNUMBER_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AccountNumber",
            SummaryCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.AccountNumber,
            Message = "Duplicate vendor bank account numbers",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorPurchasingOrganizationMinimumOrderValueAverageValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.MinimumOrderValue != null)
            .Select(x => (decimal?)x.MinimumOrderValue)
            .AverageAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            ColumnName = "MinimumOrderValue",
            SummaryCode = "VENDORPURCHASINGORG_AVERAGE_MIN_ORDER_VALUE",
            SummaryType = "AverageValue",
            Label = "Average vendor minimum order value",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "VENDORPURCHASINGORG_AVERAGE_MIN_ORDER_VALUE",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEvaluationOverallScoreAverageValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.VendorEvaluations
            .Where(x => x.OverallScore != null)
            .Select(x => (decimal?)x.OverallScore)
            .AverageAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            ColumnName = "OverallScore",
            SummaryCode = "VENDOREVALUATION_AVERAGE_OVERALL_SCORE",
            SummaryType = "AverageValue",
            Label = "Average vendor evaluation overall score",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "VENDOREVALUATION_AVERAGE_OVERALL_SCORE",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEvaluationQualityScoreMinValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.VendorEvaluations
            .Where(x => x.QualityScore != null)
            .Select(x => (decimal?)x.QualityScore)
            .MinAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            ColumnName = "QualityScore",
            SummaryCode = "VENDOREVALUATION_MIN_QUALITY_SCORE",
            SummaryType = "MinValue",
            Label = "Minimum vendor quality score",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "VENDOREVALUATION_MIN_QUALITY_SCORE",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCertificateCertificateTypeDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.VendorCertificates
            .Select(x => x.CertificateType)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            ColumnName = "CertificateType",
            SummaryCode = "VENDORCERTIFICATE_TYPE_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct vendor certificate types",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "VENDORCERTIFICATE_TYPE_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
