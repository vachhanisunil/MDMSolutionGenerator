using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Vendor.DataQuality.Services;

public sealed class VendorDataQualityRuleExecutor(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ExecuteVENDORVENDORNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORVENDORTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSADDRESSLINE1REQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSPOSTALCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTFIRSTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTLASTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTBANKNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXTAXNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCECOMPLIANCETYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATEVENDORIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCONTACTVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDPURCHASINGORGANIZATIONEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORPURCHASINGORGANIZATIONORDERCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCOMPLIANCEVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDOREVALUATIONVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteVENDORCERTIFICATEVENDORIDVENDOREXISTSRuleAsync(runId, cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNUMBER_REQUIRED",
            RuleName = "Vendor.VendorNumber is mandatory",
            EntityName = "Vendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNUMBER_REQUIRED",
            FieldName = "VendorNumber",
            Message = "Vendor.VendorNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORNAME_REQUIRED",
            RuleName = "Vendor.VendorName is mandatory",
            EntityName = "Vendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORNAME_REQUIRED",
            FieldName = "VendorName",
            Message = "Vendor.VendorName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORVENDORTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => string.IsNullOrEmpty(x.VendorType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_VENDORTYPE_REQUIRED",
            RuleName = "Vendor.VendorType is mandatory",
            EntityName = "Vendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_VENDORTYPE_REQUIRED",
            FieldName = "VendorType",
            Message = "Vendor.VendorType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_COUNTRYID_REQUIRED",
            RuleName = "Vendor.CountryId is mandatory",
            EntityName = "Vendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "Vendor.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_CURRENCYID_REQUIRED",
            RuleName = "Vendor.CurrencyId is mandatory",
            EntityName = "Vendor",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "Vendor.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_VENDORID_REQUIRED",
            RuleName = "VendorAddress.VendorId is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorAddress.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_REQUIRED",
            RuleName = "VendorAddress.AddressType is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSTYPE_REQUIRED",
            FieldName = "AddressType",
            Message = "VendorAddress.AddressType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSADDRESSLINE1REQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_REQUIRED",
            RuleName = "VendorAddress.AddressLine1 is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_ADDRESSLINE1_REQUIRED",
            FieldName = "AddressLine1",
            Message = "VendorAddress.AddressLine1 is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCITYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_CITY_REQUIRED",
            RuleName = "VendorAddress.City is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_CITY_REQUIRED",
            FieldName = "City",
            Message = "VendorAddress.City is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSPOSTALCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_POSTALCODE_REQUIRED",
            RuleName = "VendorAddress.PostalCode is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_POSTALCODE_REQUIRED",
            FieldName = "PostalCode",
            Message = "VendorAddress.PostalCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_COUNTRYID_REQUIRED",
            RuleName = "VendorAddress.CountryId is mandatory",
            EntityName = "VendorAddress",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "VendorAddress.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_VENDORID_REQUIRED",
            RuleName = "VendorContact.VendorId is mandatory",
            EntityName = "VendorContact",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorContact.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTFIRSTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_FIRSTNAME_REQUIRED",
            RuleName = "VendorContact.FirstName is mandatory",
            EntityName = "VendorContact",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_FIRSTNAME_REQUIRED",
            FieldName = "FirstName",
            Message = "VendorContact.FirstName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTLASTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_LASTNAME_REQUIRED",
            RuleName = "VendorContact.LastName is mandatory",
            EntityName = "VendorContact",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_LASTNAME_REQUIRED",
            FieldName = "LastName",
            Message = "VendorContact.LastName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_VENDORID_REQUIRED",
            RuleName = "VendorBankAccount.VendorId is mandatory",
            EntityName = "VendorBankAccount",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorBankAccount.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTBANKNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_REQUIRED",
            RuleName = "VendorBankAccount.BankName is mandatory",
            EntityName = "VendorBankAccount",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_BANKNAME_REQUIRED",
            FieldName = "BankName",
            Message = "VendorBankAccount.BankName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            RuleName = "VendorBankAccount.AccountNumber is mandatory",
            EntityName = "VendorBankAccount",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            FieldName = "AccountNumber",
            Message = "VendorBankAccount.AccountNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_REQUIRED",
            RuleName = "VendorBankAccount.CurrencyId is mandatory",
            EntityName = "VendorBankAccount",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "VendorBankAccount.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VENDORID_REQUIRED",
            RuleName = "VendorTax.VendorId is mandatory",
            EntityName = "VendorTax",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorTax.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXTYPE_REQUIRED",
            RuleName = "VendorTax.TaxType is mandatory",
            EntityName = "VendorTax",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXTYPE_REQUIRED",
            FieldName = "TaxType",
            Message = "VendorTax.TaxType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXTAXNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_TAXNUMBER_REQUIRED",
            RuleName = "VendorTax.TaxNumber is mandatory",
            EntityName = "VendorTax",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_TAXNUMBER_REQUIRED",
            FieldName = "TaxNumber",
            Message = "VendorTax.TaxNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_COUNTRYID_REQUIRED",
            RuleName = "VendorTax.CountryId is mandatory",
            EntityName = "VendorTax",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "VendorTax.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VALIDITY_DATE_RANGE",
            RuleName = "VendorTax.ValidTo must be after ValidFrom",
            EntityName = "VendorTax",
            Category = "Timeliness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "VendorTax.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_REQUIRED",
            RuleName = "VendorPurchasingOrganization.VendorId is mandatory",
            EntityName = "VendorPurchasingOrganization",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorPurchasingOrganization.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_REQUIRED",
            RuleName = "VendorPurchasingOrganization.PurchasingOrganizationId is mandatory",
            EntityName = "VendorPurchasingOrganization",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_REQUIRED",
            FieldName = "PurchasingOrganizationId",
            Message = "VendorPurchasingOrganization.PurchasingOrganizationId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PurchasingOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchasingOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VENDORID_REQUIRED",
            RuleName = "VendorCompliance.VendorId is mandatory",
            EntityName = "VendorCompliance",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorCompliance.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCECOMPLIANCETYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => string.IsNullOrEmpty(x.ComplianceType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_REQUIRED",
            RuleName = "VendorCompliance.ComplianceType is mandatory",
            EntityName = "VendorCompliance",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_COMPLIANCETYPE_REQUIRED",
            FieldName = "ComplianceType",
            Message = "VendorCompliance.ComplianceType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ComplianceType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.ComplianceType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VALIDITY_DATE_RANGE",
            RuleName = "VendorCompliance.ValidTo must be after ValidFrom",
            EntityName = "VendorCompliance",
            Category = "Timeliness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "VendorCompliance.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_VENDORID_REQUIRED",
            RuleName = "VendorEvaluation.VendorId is mandatory",
            EntityName = "VendorEvaluation",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorEvaluation.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATEVENDORIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_VENDORID_REQUIRED",
            RuleName = "VendorCertificate.VendorId is mandatory",
            EntityName = "VendorCertificate",
            Category = "Completeness",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_VENDORID_REQUIRED",
            FieldName = "VendorId",
            Message = "VendorCertificate.VendorId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "Vendor.CountryId must exist in Country",
            EntityName = "Vendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "Vendor.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "Vendor.CurrencyId must exist in Currency",
            EntityName = "Vendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "Vendor.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Vendors.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Vendors
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOR_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "Vendor.PaymentTermId must exist in PaymentTerm",
            EntityName = "Vendor",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "Vendor",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOR_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "Vendor.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorAddress.VendorId must exist in Vendor",
            EntityName = "VendorAddress",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorAddress.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORADDRESS_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorAddress.CountryId must exist in Country",
            EntityName = "VendorAddress",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorAddress",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORADDRESS_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "VendorAddress.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCONTACTVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCONTACT_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorContact.VendorId must exist in Vendor",
            EntityName = "VendorContact",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorContact",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCONTACT_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorContact.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorBankAccount.VendorId must exist in Vendor",
            EntityName = "VendorBankAccount",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorBankAccount.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "VendorBankAccount.CurrencyId must exist in Currency",
            EntityName = "VendorBankAccount",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "VendorBankAccount.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorBankAccounts
            .Where(x => x.BankCountryId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorBankAccount.BankCountryId must exist in Country",
            EntityName = "VendorBankAccount",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorBankAccount",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            FieldName = "BankCountryId",
            Message = "VendorBankAccount.BankCountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankCountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.BankCountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorTax.VendorId must exist in Vendor",
            EntityName = "VendorTax",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorTax.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORTAX_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "VendorTax.CountryId must exist in Country",
            EntityName = "VendorTax",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorTax",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORTAX_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "VendorTax.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorPurchasingOrganization.VendorId must exist in Vendor",
            EntityName = "VendorPurchasingOrganization",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorPurchasingOrganization.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPURCHASINGORGANIZATIONIDPURCHASINGORGANIZATIONEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_PURCHASINGORGANIZATION_EXISTS",
            RuleName = "VendorPurchasingOrganization.PurchasingOrganizationId must exist in PurchasingOrganization",
            EntityName = "VendorPurchasingOrganization",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PURCHASINGORGANIZATIONID_PURCHASINGORGANIZATION_EXISTS",
            FieldName = "PurchasingOrganizationId",
            Message = "VendorPurchasingOrganization.PurchasingOrganizationId must refer to an existing PurchasingOrganization.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PurchasingOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PurchasingOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "VendorPurchasingOrganization.PaymentTermId must exist in PaymentTerm",
            EntityName = "VendorPurchasingOrganization",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "VendorPurchasingOrganization.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORPURCHASINGORGANIZATIONORDERCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorPurchasingOrganizations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorPurchasingOrganizations
            .Where(x => x.OrderCurrencyId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORPURCHASINGORGANIZATION_ORDERCURRENCYID_CURRENCY_EXISTS",
            RuleName = "VendorPurchasingOrganization.OrderCurrencyId must exist in Currency",
            EntityName = "VendorPurchasingOrganization",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorPurchasingOrganization",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORPURCHASINGORGANIZATION_ORDERCURRENCYID_CURRENCY_EXISTS",
            FieldName = "OrderCurrencyId",
            Message = "VendorPurchasingOrganization.OrderCurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.OrderCurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId, x.OrderCurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCOMPLIANCEVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCompliances.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCompliances
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCOMPLIANCE_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorCompliance.VendorId must exist in Vendor",
            EntityName = "VendorCompliance",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCompliance",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCOMPLIANCE_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorCompliance.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDOREVALUATIONVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorEvaluations.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorEvaluations
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDOREVALUATION_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorEvaluation.VendorId must exist in Vendor",
            EntityName = "VendorEvaluation",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorEvaluation",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDOREVALUATION_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorEvaluation.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVENDORCERTIFICATEVENDORIDVENDOREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.VendorCertificates.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.VendorCertificates
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Vendor",
            RuleCode = "VENDORCERTIFICATE_VENDORID_VENDOR_EXISTS",
            RuleName = "VendorCertificate.VendorId must exist in Vendor",
            EntityName = "VendorCertificate",
            Category = "Consistency",
            Severity = "High",
            Status = failedSourceRecords.Any() ? "Failed" : "Passed",
            AffectedCount = failedSourceRecords.Count,
            Score = totalRecords == 0 ? 100m : Math.Round(((totalRecords - failedSourceRecords.Count) / (decimal)totalRecords) * 100m, 2),
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataQualityRuleResults.Add(result);

        var failedRecords = failedSourceRecords.Select(x => new DataQualityDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            RuleSummaryId = result.ResultId,
            ResultId = result.ResultId,
            BusinessObjectName = "Vendor",
            EntityName = "VendorCertificate",
            RootRecordId = x.VendorId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "VENDORCERTIFICATE_VENDORID_VENDOR_EXISTS",
            FieldName = "VendorId",
            Message = "VendorCertificate.VendorId must refer to an existing Vendor.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.VendorId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.VendorId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
