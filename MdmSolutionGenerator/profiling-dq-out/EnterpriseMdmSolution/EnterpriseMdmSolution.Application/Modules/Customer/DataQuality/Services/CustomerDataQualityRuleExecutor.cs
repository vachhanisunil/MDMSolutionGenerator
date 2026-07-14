using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services;

public sealed class CustomerDataQualityRuleExecutor(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ExecuteCUSTOMERCUSTOMERNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCUSTOMERTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSADDRESSLINE1REQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCITYREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSPOSTALCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTFIRSTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTLASTNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTBANKNAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXTAXNUMBERREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCOUNTRYIDREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXVALIDITYDATERANGERuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECREDITLIMITREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTFILENAMEREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTSTORAGEPATHREQUIREDRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCONTACTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREACUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDSALESORGANIZATIONEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERSALESAREAPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITPROFILECUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERATTACHMENTCUSTOMERIDCUSTOMEREXISTSRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERINDIAREQUIRESGSTTAXRuleAsync(runId, cancellationToken);
        await ExecuteCUSTOMERCREDITEXPOSUREWITHINLIMITRuleAsync(runId, cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_REQUIRED",
            RuleName = "Customer.CustomerNumber is mandatory",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNUMBER_REQUIRED",
            FieldName = "CustomerNumber",
            Message = "Customer.CustomerNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERNAME_REQUIRED",
            RuleName = "Customer.CustomerName is mandatory",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERNAME_REQUIRED",
            FieldName = "CustomerName",
            Message = "Customer.CustomerName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCUSTOMERTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CUSTOMERTYPE_REQUIRED",
            RuleName = "Customer.CustomerType is mandatory",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CUSTOMERTYPE_REQUIRED",
            FieldName = "CustomerType",
            Message = "Customer.CustomerType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_COUNTRYID_REQUIRED",
            RuleName = "Customer.CountryId is mandatory",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "Customer.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CURRENCYID_REQUIRED",
            RuleName = "Customer.CurrencyId is mandatory",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "Customer.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_REQUIRED",
            RuleName = "CustomerAddress.AddressType is mandatory",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSTYPE_REQUIRED",
            FieldName = "AddressType",
            Message = "CustomerAddress.AddressType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSADDRESSLINE1REQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_REQUIRED",
            RuleName = "CustomerAddress.AddressLine1 is mandatory",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_ADDRESSLINE1_REQUIRED",
            FieldName = "AddressLine1",
            Message = "CustomerAddress.AddressLine1 is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AddressLine1,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCITYREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CITY_REQUIRED",
            RuleName = "CustomerAddress.City is mandatory",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CITY_REQUIRED",
            FieldName = "City",
            Message = "CustomerAddress.City is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.City,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSPOSTALCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_REQUIRED",
            RuleName = "CustomerAddress.PostalCode is mandatory",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_POSTALCODE_REQUIRED",
            FieldName = "PostalCode",
            Message = "CustomerAddress.PostalCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PostalCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_REQUIRED",
            RuleName = "CustomerAddress.CountryId is mandatory",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "CustomerAddress.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTFIRSTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_REQUIRED",
            RuleName = "CustomerContact.FirstName is mandatory",
            EntityName = "CustomerContact",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_FIRSTNAME_REQUIRED",
            FieldName = "FirstName",
            Message = "CustomerContact.FirstName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FirstName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTLASTNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_LASTNAME_REQUIRED",
            RuleName = "CustomerContact.LastName is mandatory",
            EntityName = "CustomerContact",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_LASTNAME_REQUIRED",
            FieldName = "LastName",
            Message = "CustomerContact.LastName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.LastName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTBANKNAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_REQUIRED",
            RuleName = "CustomerBankAccount.BankName is mandatory",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_BANKNAME_REQUIRED",
            FieldName = "BankName",
            Message = "CustomerBankAccount.BankName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTACCOUNTNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            RuleName = "CustomerBankAccount.AccountNumber is mandatory",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_REQUIRED",
            FieldName = "AccountNumber",
            Message = "CustomerBankAccount.AccountNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.AccountNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCURRENCYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_REQUIRED",
            RuleName = "CustomerBankAccount.CurrencyId is mandatory",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_REQUIRED",
            FieldName = "CurrencyId",
            Message = "CustomerBankAccount.CurrencyId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXTYPE_REQUIRED",
            RuleName = "CustomerTax.TaxType is mandatory",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXTYPE_REQUIRED",
            FieldName = "TaxType",
            Message = "CustomerTax.TaxType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXTAXNUMBERREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_TAXNUMBER_REQUIRED",
            RuleName = "CustomerTax.TaxNumber is mandatory",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_TAXNUMBER_REQUIRED",
            FieldName = "TaxNumber",
            Message = "CustomerTax.TaxNumber is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.TaxNumber,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCOUNTRYIDREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_COUNTRYID_REQUIRED",
            RuleName = "CustomerTax.CountryId is mandatory",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_COUNTRYID_REQUIRED",
            FieldName = "CountryId",
            Message = "CustomerTax.CountryId is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXVALIDITYDATERANGERuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => x.ValidTo < x.ValidFrom)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_VALIDITY_DATE_RANGE",
            RuleName = "CustomerTax.ValidTo must be after ValidFrom",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_VALIDITY_DATE_RANGE",
            FieldName = "",
            Message = "CustomerTax.ValidTo cannot be earlier than ValidFrom.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_REQUIRED",
            RuleName = "CustomerClassification.ClassificationType is mandatory",
            EntityName = "CustomerClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_REQUIRED",
            FieldName = "ClassificationType",
            Message = "CustomerClassification.ClassificationType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassificationType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCLASSIFICATIONVALUEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationValue))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_REQUIRED",
            RuleName = "CustomerClassification.ClassificationValue is mandatory",
            EntityName = "CustomerClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_REQUIRED",
            FieldName = "ClassificationValue",
            Message = "CustomerClassification.ClassificationValue is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.ClassificationValue,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITCONTROLAREAREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditControlArea))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_REQUIRED",
            RuleName = "CustomerCreditProfile.CreditControlArea is mandatory",
            EntityName = "CustomerCreditProfile",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_REQUIRED",
            FieldName = "CreditControlArea",
            Message = "CustomerCreditProfile.CreditControlArea is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditControlArea,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditControlArea }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECREDITLIMITREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_REQUIRED",
            RuleName = "CustomerCreditProfile.CreditLimit is mandatory",
            EntityName = "CustomerCreditProfile",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_REQUIRED",
            FieldName = "CreditLimit",
            Message = "CustomerCreditProfile.CreditLimit is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CreditLimit.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONPARTNERFUNCTIONCODEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => string.IsNullOrEmpty(x.PartnerFunctionCode))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_REQUIRED",
            RuleName = "CustomerPartnerFunction.PartnerFunctionCode is mandatory",
            EntityName = "CustomerPartnerFunction",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_REQUIRED",
            FieldName = "PartnerFunctionCode",
            Message = "CustomerPartnerFunction.PartnerFunctionCode is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PartnerFunctionCode,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PartnerFunctionCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTDOCUMENTTYPEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.DocumentType))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_REQUIRED",
            RuleName = "CustomerAttachment.DocumentType is mandatory",
            EntityName = "CustomerAttachment",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_REQUIRED",
            FieldName = "DocumentType",
            Message = "CustomerAttachment.DocumentType is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.DocumentType,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DocumentType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTFILENAMEREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.FileName))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_REQUIRED",
            RuleName = "CustomerAttachment.FileName is mandatory",
            EntityName = "CustomerAttachment",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_FILENAME_REQUIRED",
            FieldName = "FileName",
            Message = "CustomerAttachment.FileName is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.FileName,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FileName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTSTORAGEPATHREQUIREDRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.StoragePath))
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_REQUIRED",
            RuleName = "CustomerAttachment.StoragePath is mandatory",
            EntityName = "CustomerAttachment",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_STORAGEPATH_REQUIRED",
            FieldName = "StoragePath",
            Message = "CustomerAttachment.StoragePath is required.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.StoragePath,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.StoragePath }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "Customer.CountryId must exist in Country",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "Customer.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "Customer.CurrencyId must exist in Currency",
            EntityName = "Customer",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "Customer.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerAddress.CustomerId must exist in Customer",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerAddress.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERADDRESSCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerAddress.CountryId must exist in Country",
            EntityName = "CustomerAddress",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERADDRESS_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "CustomerAddress.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCONTACTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerContact.CustomerId must exist in Customer",
            EntityName = "CustomerContact",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCONTACT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerContact.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerBankAccount.CustomerId must exist in Customer",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerBankAccount.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTCURRENCYIDCURRENCYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            RuleName = "CustomerBankAccount.CurrencyId must exist in Currency",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_CURRENCYID_CURRENCY_EXISTS",
            FieldName = "CurrencyId",
            Message = "CustomerBankAccount.CurrencyId must refer to an existing Currency.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CurrencyId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERBANKACCOUNTBANKCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => x.BankCountryId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerBankAccount.BankCountryId must exist in Country",
            EntityName = "CustomerBankAccount",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERBANKACCOUNT_BANKCOUNTRYID_COUNTRY_EXISTS",
            FieldName = "BankCountryId",
            Message = "CustomerBankAccount.BankCountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.BankCountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankCountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREACUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerSalesArea.CustomerId must exist in Customer",
            EntityName = "CustomerSalesArea",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerSalesArea.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREASALESORGANIZATIONIDSALESORGANIZATIONEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_SALESORGANIZATION_EXISTS",
            RuleName = "CustomerSalesArea.SalesOrganizationId must exist in SalesOrganization",
            EntityName = "CustomerSalesArea",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_SALESORGANIZATIONID_SALESORGANIZATION_EXISTS",
            FieldName = "SalesOrganizationId",
            Message = "CustomerSalesArea.SalesOrganizationId must refer to an existing SalesOrganization.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.SalesOrganizationId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.SalesOrganizationId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERSALESAREAPAYMENTTERMIDPAYMENTTERMEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => x.PaymentTermId == null)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERSALESAREA_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            RuleName = "CustomerSalesArea.PaymentTermId must exist in PaymentTerm",
            EntityName = "CustomerSalesArea",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERSALESAREA_PAYMENTTERMID_PAYMENTTERM_EXISTS",
            FieldName = "PaymentTermId",
            Message = "CustomerSalesArea.PaymentTermId must refer to an existing PaymentTerm.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.PaymentTermId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PaymentTermId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerTax.CustomerId must exist in Customer",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerTax.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERTAXCOUNTRYIDCOUNTRYEXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERTAX_COUNTRYID_COUNTRY_EXISTS",
            RuleName = "CustomerTax.CountryId must exist in Country",
            EntityName = "CustomerTax",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERTAX_COUNTRYID_COUNTRY_EXISTS",
            FieldName = "CountryId",
            Message = "CustomerTax.CountryId must refer to an existing Country.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CountryId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCLASSIFICATIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerClassification.CustomerId must exist in Customer",
            EntityName = "CustomerClassification",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCLASSIFICATION_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerClassification.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERCREDITPROFILECUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerCreditProfile.CustomerId must exist in Customer",
            EntityName = "CustomerCreditProfile",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERCREDITPROFILE_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerCreditProfile.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERPARTNERFUNCTIONCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerPartnerFunction.CustomerId must exist in Customer",
            EntityName = "CustomerPartnerFunction",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERPARTNERFUNCTION_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerPartnerFunction.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERATTACHMENTCUSTOMERIDCUSTOMEREXISTSRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_CUSTOMER_EXISTS",
            RuleName = "CustomerAttachment.CustomerId must exist in Customer",
            EntityName = "CustomerAttachment",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMERATTACHMENT_CUSTOMERID_CUSTOMER_EXISTS",
            FieldName = "CustomerId",
            Message = "CustomerAttachment.CustomerId must refer to an existing Customer.",
            Severity = "High",
            Status = "Open",
            FieldValue = x.CustomerId.ToString(),
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteCUSTOMERINDIAREQUIRESGSTTAXRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        // TODO: Implement custom business rule logic here.
        // This rule requires custom logic because it cannot be generated safely from metadata alone.
        await Task.CompletedTask;
    }

    private async Task ExecuteCUSTOMERCREDITEXPOSUREWITHINLIMITRuleAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);

        var failedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var result = new DataQualityRuleResult
        {
            ResultId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            RuleCode = "CUSTOMER_CREDIT_EXPOSURE_WITHIN_LIMIT",
            RuleName = "Customer credit exposure should not exceed credit limit",
            EntityName = "CustomerCreditProfile",
            Category = "Accuracy",
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
            ResultId = result.ResultId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            RuleCode = "CUSTOMER_CREDIT_EXPOSURE_WITHIN_LIMIT",
            FieldName = "",
            Message = "Credit exposure cannot exceed credit limit.",
            Severity = "High",
            Status = "Open",
            FieldValue = null,
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataQualityDrilldowns.AddRange(failedRecords);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
