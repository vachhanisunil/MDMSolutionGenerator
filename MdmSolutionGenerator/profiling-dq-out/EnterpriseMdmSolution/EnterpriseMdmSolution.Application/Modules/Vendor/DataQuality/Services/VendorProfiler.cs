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
        await ProfileVendorVendorNumberNullCountAsync(runId, cancellationToken);
        await ProfileVendorVendorNameNullCountAsync(runId, cancellationToken);
        await ProfileVendorVendorTypeNullCountAsync(runId, cancellationToken);
        await ProfileVendorAddressAddressTypeNullCountAsync(runId, cancellationToken);
        await ProfileVendorAddressAddressLine1NullCountAsync(runId, cancellationToken);
        await ProfileVendorAddressCityNullCountAsync(runId, cancellationToken);
        await ProfileVendorAddressPostalCodeNullCountAsync(runId, cancellationToken);
        await ProfileVendorContactFirstNameNullCountAsync(runId, cancellationToken);
        await ProfileVendorContactLastNameNullCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountBankNameNullCountAsync(runId, cancellationToken);
        await ProfileVendorBankAccountAccountNumberNullCountAsync(runId, cancellationToken);
        await ProfileVendorTaxTaxTypeNullCountAsync(runId, cancellationToken);
        await ProfileVendorTaxTaxNumberNullCountAsync(runId, cancellationToken);
        await ProfileVendorComplianceComplianceTypeNullCountAsync(runId, cancellationToken);
        await ProfileVendorComplianceComplianceStatusNullCountAsync(runId, cancellationToken);
        await ProfileVendorEvaluationEvaluationPeriodNullCountAsync(runId, cancellationToken);
        await ProfileVendorCertificateCertificateTypeNullCountAsync(runId, cancellationToken);
        await ProfileVendorCertificateCertificateNameNullCountAsync(runId, cancellationToken);
    }

    private async Task ProfileVendorVendorNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDOR_VENDORNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Vendor VendorNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDOR_VENDORNUMBER_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDOR_VENDORNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.VendorNumber,
                Message = "Vendor VendorNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDOR_VENDORNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Vendor VendorName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDOR_VENDORNAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDOR_VENDORNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.VendorName,
                Message = "Vendor VendorName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorVendorTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDOR_VENDORTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Vendor VendorType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDOR_VENDORTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDOR_VENDORTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.VendorType,
                Message = "Vendor VendorType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressAddressTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORADDRESS_ADDRESSTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorAddress AddressType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORADDRESS_ADDRESSTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORADDRESS_ADDRESSTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AddressType,
                Message = "VendorAddress AddressType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressAddressLine1NullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORADDRESS_ADDRESSLINE1_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorAddress AddressLine1 missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORADDRESS_ADDRESSLINE1_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORADDRESS_ADDRESSLINE1_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AddressLine1,
                Message = "VendorAddress AddressLine1 missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine1 }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressCityNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORADDRESS_CITY_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorAddress City missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORADDRESS_CITY_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORADDRESS_CITY_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.City,
                Message = "VendorAddress City missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.City }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorAddressPostalCodeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORADDRESS_POSTALCODE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorAddress PostalCode missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORADDRESS_POSTALCODE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORADDRESS_POSTALCODE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.PostalCode,
                Message = "VendorAddress PostalCode missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PostalCode }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactFirstNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORCONTACT_FIRSTNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorContact FirstName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCONTACT_FIRSTNAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORCONTACT_FIRSTNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.FirstName,
                Message = "VendorContact FirstName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.FirstName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorContactLastNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORCONTACT_LASTNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorContact LastName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCONTACT_LASTNAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORCONTACT_LASTNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.LastName,
                Message = "VendorContact LastName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.LastName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountBankNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORBANKACCOUNT_BANKNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorBankAccount BankName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORBANKACCOUNT_BANKNAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORBANKACCOUNT_BANKNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.BankName,
                Message = "VendorBankAccount BankName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorBankAccountAccountNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorBankAccount AccountNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AccountNumber,
                Message = "VendorBankAccount AccountNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxTaxTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORTAX_TAXTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorTax TaxType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORTAX_TAXTYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORTAX_TAXTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.TaxType,
                Message = "VendorTax TaxType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorTaxTaxNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORTAX_TAXNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorTax TaxNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORTAX_TAXNUMBER_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORTAX_TAXNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.TaxNumber,
                Message = "VendorTax TaxNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorComplianceComplianceTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "VENDOR_VENDORCOMPLIANCE_COMPLIANCETYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorCompliance ComplianceType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCOMPLIANCE_COMPLIANCETYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
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
                SummaryCode = "VENDOR_VENDORCOMPLIANCE_COMPLIANCETYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ComplianceType,
                Message = "VendorCompliance ComplianceType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorComplianceComplianceStatusNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceStatus))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            ColumnName = "ComplianceStatus",
            SummaryCode = "VENDOR_VENDORCOMPLIANCE_COMPLIANCESTATUS_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorCompliance ComplianceStatus missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCOMPLIANCE_COMPLIANCESTATUS_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorCompliance",
                RootRecordId = x.VendorId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ComplianceStatus",
                SummaryCode = "VENDOR_VENDORCOMPLIANCE_COMPLIANCESTATUS_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ComplianceStatus,
                Message = "VendorCompliance ComplianceStatus missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceStatus }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorEvaluationEvaluationPeriodNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => string.IsNullOrEmpty(x.EvaluationPeriod))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            ColumnName = "EvaluationPeriod",
            SummaryCode = "VENDOR_VENDOREVALUATION_EVALUATIONPERIOD_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorEvaluation EvaluationPeriod missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDOREVALUATION_EVALUATIONPERIOD_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorEvaluation",
                RootRecordId = x.VendorId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "EvaluationPeriod",
                SummaryCode = "VENDOR_VENDOREVALUATION_EVALUATIONPERIOD_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.EvaluationPeriod,
                Message = "VendorEvaluation EvaluationPeriod missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.EvaluationPeriod }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCertificateCertificateTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            ColumnName = "CertificateType",
            SummaryCode = "VENDOR_VENDORCERTIFICATE_CERTIFICATETYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorCertificate CertificateType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCERTIFICATE_CERTIFICATETYPE_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorCertificate",
                RootRecordId = x.VendorId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CertificateType",
                SummaryCode = "VENDOR_VENDORCERTIFICATE_CERTIFICATETYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CertificateType,
                Message = "VendorCertificate CertificateType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileVendorCertificateCertificateNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => string.IsNullOrEmpty(x.CertificateName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            ColumnName = "CertificateName",
            SummaryCode = "VENDOR_VENDORCERTIFICATE_CERTIFICATENAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "VendorCertificate CertificateName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "VENDOR_VENDORCERTIFICATE_CERTIFICATENAME_NULL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        if (true)
        {
            var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
            {
                DrilldownId = Guid.NewGuid(),
                RunId = runId,
                SummaryId = summary.SummaryId,
                BusinessObjectName = "Vendor",
                EntityName = "VendorCertificate",
                RootRecordId = x.VendorId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CertificateName",
                SummaryCode = "VENDOR_VENDORCERTIFICATE_CERTIFICATENAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CertificateName,
                Message = "VendorCertificate CertificateName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CertificateName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
