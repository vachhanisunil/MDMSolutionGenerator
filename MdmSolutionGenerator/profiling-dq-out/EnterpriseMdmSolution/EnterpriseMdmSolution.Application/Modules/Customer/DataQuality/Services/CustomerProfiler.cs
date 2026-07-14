using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Application.Common;
using EnterpriseMdmSolution.Core.DataQuality;

namespace EnterpriseMdmSolution.Application.Modules.Customer.DataQuality.Services;

public sealed class CustomerProfiler(IAnalysisDbContext dbContext)
{
    private readonly IAnalysisDbContext _dbContext = dbContext;

    public async Task ExecuteAsync(Guid runId, CancellationToken cancellationToken)
    {
        await ProfileCustomerRecordsTotalRootObjectsAsync(runId, cancellationToken);
        await ProfileCustomerRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerCustomerNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCustomerNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCustomerTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerEmailInvalidFormatCountAsync(runId, cancellationToken);
        await ProfileCustomerCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCurrencyIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerAddressAddressTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressAddressLine1NullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressCityNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressPostalCodeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerContactRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerContactFirstNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerContactLastNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerContactEmailInvalidFormatCountAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountBankNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountAccountNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountCurrencyIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaCreditLimitBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileCustomerTaxRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerTaxTaxTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerTaxTaxNumberNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerTaxCountryIdNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerClassificationRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerClassificationClassificationTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerClassificationClassificationValueNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditControlAreaNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditLimitNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditLimitBelowMinimumCountAsync(runId, cancellationToken);
        await ProfileCustomerPartnerFunctionRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerPartnerFunctionPartnerFunctionCodeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentRecordsTotalRecordsAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentDocumentTypeNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentFileNameNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentStoragePathNullOrEmptyCountAsync(runId, cancellationToken);
        await ProfileCustomerCustomerTypeDistinctCountAsync(runId, cancellationToken);
        await ProfileCustomerRiskCategoryDistinctCountAsync(runId, cancellationToken);
        await ProfileCustomerEmailDuplicateCountAsync(runId, cancellationToken);
        await ProfileCustomerRegistrationNumberDuplicateCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressCityDistinctCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressPostalCodeDistinctCountAsync(runId, cancellationToken);
        await ProfileCustomerContactEmailDuplicateCountAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaCreditLimitAverageValueAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaCreditLimitMaxValueAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditExposureAverageValueAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditExposureMaxValueAsync(runId, cancellationToken);
        await ProfileCustomerClassificationClassificationTypeDistinctCountAsync(runId, cancellationToken);
    }

    private async Task ProfileCustomerRecordsTotalRootObjectsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "",
            SummaryCode = "CUSTOMER_ROOT_OBJECT_COUNT",
            SummaryType = "TotalRootObjects",
            Label = "Total Customer root objects",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMER_ROOT_OBJECT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "",
            SummaryCode = "CUSTOMER_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in Customer",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMER_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CustomerNumber",
            SummaryCode = "CUSTOMER_CUSTOMERNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Customer.CustomerNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CustomerNumber",
            SummaryCode = "CUSTOMER_CUSTOMERNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CustomerNumber,
            Message = "Customer.CustomerNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CustomerName",
            SummaryCode = "CUSTOMER_CUSTOMERNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Customer.CustomerName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CustomerName",
            SummaryCode = "CUSTOMER_CUSTOMERNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CustomerName,
            Message = "Customer.CustomerName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => string.IsNullOrEmpty(x.CustomerType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CustomerType",
            SummaryCode = "CUSTOMER_CUSTOMERTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Customer.CustomerType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CustomerType",
            SummaryCode = "CUSTOMER_CUSTOMERTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CustomerType,
            Message = "Customer.CustomerType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerEmailInvalidFormatCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => x.Email != null && !x.Email.Contains("@"))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "Email",
            SummaryCode = "CUSTOMER_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            Label = "Invalid email format in Customer.Email",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_EMAIL_INVALID_EMAIL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "CUSTOMER_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            FieldValue = x.Email,
            Message = "Invalid email format in Customer.Email",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMER_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Customer.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMER_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "Customer.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCurrencyIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.Customers.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CurrencyId",
            SummaryCode = "CUSTOMER_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "Customer.CurrencyId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CURRENCYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CurrencyId",
            SummaryCode = "CUSTOMER_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CurrencyId.ToString(),
            Message = "Customer.CurrencyId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "",
            SummaryCode = "CUSTOMERADDRESS_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerAddress",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERADDRESS_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressAddressTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "AddressType",
            SummaryCode = "CUSTOMERADDRESS_ADDRESSTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAddress.AddressType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERADDRESS_ADDRESSTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AddressType",
            SummaryCode = "CUSTOMERADDRESS_ADDRESSTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AddressType,
            Message = "CustomerAddress.AddressType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressAddressLine1NullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.AddressLine1))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "AddressLine1",
            SummaryCode = "CUSTOMERADDRESS_ADDRESSLINE1_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAddress.AddressLine1 missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERADDRESS_ADDRESSLINE1_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AddressLine1",
            SummaryCode = "CUSTOMERADDRESS_ADDRESSLINE1_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AddressLine1,
            Message = "CustomerAddress.AddressLine1 missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine1 }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressCityNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.City))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "City",
            SummaryCode = "CUSTOMERADDRESS_CITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAddress.City missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERADDRESS_CITY_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "City",
            SummaryCode = "CUSTOMERADDRESS_CITY_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.City,
            Message = "CustomerAddress.City missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.City }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressPostalCodeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => string.IsNullOrEmpty(x.PostalCode))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "PostalCode",
            SummaryCode = "CUSTOMERADDRESS_POSTALCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAddress.PostalCode missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERADDRESS_POSTALCODE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PostalCode",
            SummaryCode = "CUSTOMERADDRESS_POSTALCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PostalCode,
            Message = "CustomerAddress.PostalCode missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PostalCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAddresses.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAddresses
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMERADDRESS_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAddress.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERADDRESS_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMERADDRESS_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "CustomerAddress.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            ColumnName = "",
            SummaryCode = "CUSTOMERCONTACT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerContact",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCONTACT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactFirstNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.FirstName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            ColumnName = "FirstName",
            SummaryCode = "CUSTOMERCONTACT_FIRSTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerContact.FirstName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCONTACT_FIRSTNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "FirstName",
            SummaryCode = "CUSTOMERCONTACT_FIRSTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.FirstName,
            Message = "CustomerContact.FirstName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FirstName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactLastNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => string.IsNullOrEmpty(x.LastName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            ColumnName = "LastName",
            SummaryCode = "CUSTOMERCONTACT_LASTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerContact.LastName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCONTACT_LASTNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "LastName",
            SummaryCode = "CUSTOMERCONTACT_LASTNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.LastName,
            Message = "CustomerContact.LastName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.LastName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactEmailInvalidFormatCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerContacts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => x.Email != null && !x.Email.Contains("@"))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            ColumnName = "Email",
            SummaryCode = "CUSTOMERCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            Label = "Invalid email format in CustomerContact.Email",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "CUSTOMERCONTACT_EMAIL_INVALID_EMAIL_COUNT",
            SummaryType = "InvalidFormatCount",
            FieldValue = x.Email,
            Message = "Invalid email format in CustomerContact.Email",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            ColumnName = "",
            SummaryCode = "CUSTOMERBANKACCOUNT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerBankAccount",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERBANKACCOUNT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountBankNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.BankName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            ColumnName = "BankName",
            SummaryCode = "CUSTOMERBANKACCOUNT_BANKNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerBankAccount.BankName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERBANKACCOUNT_BANKNAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "BankName",
            SummaryCode = "CUSTOMERBANKACCOUNT_BANKNAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.BankName,
            Message = "CustomerBankAccount.BankName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountAccountNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => string.IsNullOrEmpty(x.AccountNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            ColumnName = "AccountNumber",
            SummaryCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerBankAccount.AccountNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "AccountNumber",
            SummaryCode = "CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.AccountNumber,
            Message = "CustomerBankAccount.AccountNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountCurrencyIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerBankAccounts.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerBankAccounts
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            ColumnName = "CurrencyId",
            SummaryCode = "CUSTOMERBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerBankAccount.CurrencyId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerBankAccount",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CurrencyId",
            SummaryCode = "CUSTOMERBANKACCOUNT_CURRENCYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CurrencyId.ToString(),
            Message = "CustomerBankAccount.CurrencyId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CurrencyId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "",
            SummaryCode = "CUSTOMERSALESAREA_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerSalesArea",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERSALESAREA_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaCreditLimitBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => x.CreditLimit < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERSALESAREA_CREDITLIMIT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "CustomerSalesArea.CreditLimit below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERSALESAREA_CREDITLIMIT_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERSALESAREA_CREDITLIMIT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.CreditLimit.ToString(),
            Message = "CustomerSalesArea.CreditLimit below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            ColumnName = "",
            SummaryCode = "CUSTOMERTAX_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerTax",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERTAX_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxTaxTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            ColumnName = "TaxType",
            SummaryCode = "CUSTOMERTAX_TAXTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerTax.TaxType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERTAX_TAXTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "TaxType",
            SummaryCode = "CUSTOMERTAX_TAXTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.TaxType,
            Message = "CustomerTax.TaxType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxTaxNumberNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => string.IsNullOrEmpty(x.TaxNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            ColumnName = "TaxNumber",
            SummaryCode = "CUSTOMERTAX_TAXNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerTax.TaxNumber missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERTAX_TAXNUMBER_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "TaxNumber",
            SummaryCode = "CUSTOMERTAX_TAXNUMBER_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.TaxNumber,
            Message = "CustomerTax.TaxNumber missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxCountryIdNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerTaxs.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerTaxs
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMERTAX_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerTax.CountryId missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERTAX_COUNTRYID_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerTax",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CountryId",
            SummaryCode = "CUSTOMERTAX_COUNTRYID_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CountryId.ToString(),
            Message = "CustomerTax.CountryId missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CountryId }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            ColumnName = "",
            SummaryCode = "CUSTOMERCLASSIFICATION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerClassification",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCLASSIFICATION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationClassificationTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            ColumnName = "ClassificationType",
            SummaryCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerClassification.ClassificationType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ClassificationType",
            SummaryCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ClassificationType,
            Message = "CustomerClassification.ClassificationType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationClassificationValueNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerClassifications.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerClassifications
            .Where(x => string.IsNullOrEmpty(x.ClassificationValue))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            ColumnName = "ClassificationValue",
            SummaryCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerClassification.ClassificationValue missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "ClassificationValue",
            SummaryCode = "CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.ClassificationValue,
            Message = "CustomerClassification.ClassificationValue missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationValue }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "",
            SummaryCode = "CUSTOMERCREDITPROFILE_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerCreditProfile",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCREDITPROFILE_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditControlAreaNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => string.IsNullOrEmpty(x.CreditControlArea))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "CreditControlArea",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerCreditProfile.CreditControlArea missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CreditControlArea",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CreditControlArea,
            Message = "CustomerCreditProfile.CreditControlArea missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditControlArea }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditLimitNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => false)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerCreditProfile.CreditLimit missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCREDITPROFILE_CREDITLIMIT_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.CreditLimit.ToString(),
            Message = "CustomerCreditProfile.CreditLimit missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditLimitBelowMinimumCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerCreditProfiles.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerCreditProfiles
            .Where(x => x.CreditLimit < 0)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            Label = "CustomerCreditProfile.CreditLimit below minimum 0",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCREDITPROFILE_CREDITLIMIT_BELOW_MIN",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERCREDITPROFILE_CREDITLIMIT_BELOW_MIN",
            SummaryType = "BelowMinimumCount",
            FieldValue = x.CreditLimit.ToString(),
            Message = "CustomerCreditProfile.CreditLimit below minimum 0",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditLimit }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerPartnerFunctionRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            ColumnName = "",
            SummaryCode = "CUSTOMERPARTNERFUNCTION_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerPartnerFunction",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERPARTNERFUNCTION_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerPartnerFunctionPartnerFunctionCodeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerPartnerFunctions.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerPartnerFunctions
            .Where(x => string.IsNullOrEmpty(x.PartnerFunctionCode))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            ColumnName = "PartnerFunctionCode",
            SummaryCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerPartnerFunction.PartnerFunctionCode missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerPartnerFunction",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "PartnerFunctionCode",
            SummaryCode = "CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.PartnerFunctionCode,
            Message = "CustomerPartnerFunction.PartnerFunctionCode missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PartnerFunctionCode }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentRecordsTotalRecordsAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => true)
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            ColumnName = "",
            SummaryCode = "CUSTOMERATTACHMENT_TOTAL_RECORD_COUNT",
            SummaryType = "TotalRecords",
            Label = "Total records in CustomerAttachment",
            Severity = "",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERATTACHMENT_TOTAL_RECORD_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);


        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentDocumentTypeNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.DocumentType))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            ColumnName = "DocumentType",
            SummaryCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAttachment.DocumentType missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERATTACHMENT_DOCUMENTTYPE_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "DocumentType",
            SummaryCode = "CUSTOMERATTACHMENT_DOCUMENTTYPE_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.DocumentType,
            Message = "CustomerAttachment.DocumentType missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DocumentType }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentFileNameNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.FileName))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            ColumnName = "FileName",
            SummaryCode = "CUSTOMERATTACHMENT_FILENAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAttachment.FileName missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERATTACHMENT_FILENAME_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "FileName",
            SummaryCode = "CUSTOMERATTACHMENT_FILENAME_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.FileName,
            Message = "CustomerAttachment.FileName missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FileName }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentStoragePathNullOrEmptyCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerAttachments.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerAttachments
            .Where(x => string.IsNullOrEmpty(x.StoragePath))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            ColumnName = "StoragePath",
            SummaryCode = "CUSTOMERATTACHMENT_STORAGEPATH_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            Label = "CustomerAttachment.StoragePath missing values",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERATTACHMENT_STORAGEPATH_MISSING_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAttachment",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "StoragePath",
            SummaryCode = "CUSTOMERATTACHMENT_STORAGEPATH_MISSING_COUNT",
            SummaryType = "NullOrEmptyCount",
            FieldValue = x.StoragePath,
            Message = "CustomerAttachment.StoragePath missing values",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.StoragePath }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerTypeDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.Customers
            .Select(x => x.CustomerType)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "CustomerType",
            SummaryCode = "CUSTOMER_CUSTOMERTYPE_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct customer types",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMER_CUSTOMERTYPE_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerRiskCategoryDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.Customers
            .Select(x => x.RiskCategory)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "RiskCategory",
            SummaryCode = "CUSTOMER_RISKCATEGORY_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct customer risk categories",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMER_RISKCATEGORY_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerEmailDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.Customers
            .Where(x => x.Email != null && x.Email != "")
            .GroupBy(x => x.Email)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => duplicateValues.Contains(x.Email))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "Email",
            SummaryCode = "CUSTOMER_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate customer email records",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_EMAIL_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "CUSTOMER_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.Email,
            Message = "Duplicate customer email records",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerRegistrationNumberDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.Customers
            .Where(x => x.RegistrationNumber != null && x.RegistrationNumber != "")
            .GroupBy(x => x.RegistrationNumber)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.Customers
            .Where(x => duplicateValues.Contains(x.RegistrationNumber))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            ColumnName = "RegistrationNumber",
            SummaryCode = "CUSTOMER_REGISTRATIONNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate customer registration numbers",
            Severity = "High",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_REGISTRATIONNUMBER_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "Customer",
            RootRecordId = x.Id.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "RegistrationNumber",
            SummaryCode = "CUSTOMER_REGISTRATIONNUMBER_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.RegistrationNumber,
            Message = "Duplicate customer registration numbers",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.RegistrationNumber }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressCityDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerAddresses
            .Select(x => x.City)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "City",
            SummaryCode = "CUSTOMERADDRESS_CITY_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct customer address cities",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERADDRESS_CITY_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressPostalCodeDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerAddresses
            .Select(x => x.PostalCode)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerAddress",
            ColumnName = "PostalCode",
            SummaryCode = "CUSTOMERADDRESS_POSTALCODE_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct customer postal codes",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERADDRESS_POSTALCODE_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactEmailDuplicateCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var duplicateValues = await _dbContext.CustomerContacts
            .Where(x => x.Email != null && x.Email != "")
            .GroupBy(x => x.Email)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToListAsync(cancellationToken);

        var affectedSourceRecords = await _dbContext.CustomerContacts
            .Where(x => duplicateValues.Contains(x.Email))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            ColumnName = "Email",
            SummaryCode = "CUSTOMERCONTACT_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            Label = "Duplicate customer contact email records",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMERCONTACT_EMAIL_DUPLICATE_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        var affectedRecords = affectedSourceRecords.Select(x => new DataProfilingDrilldown
        {
            DrilldownId = Guid.NewGuid(),
            RunId = runId,
            SummaryId = summary.SummaryId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerContact",
            RootRecordId = x.CustomerId.ToString(),
            RecordId = x.Id.ToString(),
            ColumnName = "Email",
            SummaryCode = "CUSTOMERCONTACT_EMAIL_DUPLICATE_COUNT",
            SummaryType = "DuplicateCount",
            FieldValue = x.Email,
            Message = "Duplicate customer contact email records",
            RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Email }),
            CreatedOn = DateTimeOffset.UtcNow
        }).ToList();

        _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaCreditLimitAverageValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerSalesAreas
            .Where(x => x.CreditLimit != null)
            .Select(x => (decimal?)x.CreditLimit)
            .AverageAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERSALESAREA_AVERAGE_CREDIT_LIMIT",
            SummaryType = "AverageValue",
            Label = "Average customer sales area credit limit",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERSALESAREA_AVERAGE_CREDIT_LIMIT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaCreditLimitMaxValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerSalesAreas
            .Where(x => x.CreditLimit != null)
            .Select(x => (decimal?)x.CreditLimit)
            .MaxAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "CreditLimit",
            SummaryCode = "CUSTOMERSALESAREA_MAX_CREDIT_LIMIT",
            SummaryType = "MaxValue",
            Label = "Maximum customer sales area credit limit",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERSALESAREA_MAX_CREDIT_LIMIT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditExposureAverageValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerCreditProfiles
            .Where(x => x.CreditExposure != null)
            .Select(x => (decimal?)x.CreditExposure)
            .AverageAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "CreditExposure",
            SummaryCode = "CUSTOMERCREDITPROFILE_AVERAGE_CREDIT_EXPOSURE",
            SummaryType = "AverageValue",
            Label = "Average customer credit exposure",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCREDITPROFILE_AVERAGE_CREDIT_EXPOSURE",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditExposureMaxValueAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerCreditProfiles
            .Where(x => x.CreditExposure != null)
            .Select(x => (decimal?)x.CreditExposure)
            .MaxAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerCreditProfile",
            ColumnName = "CreditExposure",
            SummaryCode = "CUSTOMERCREDITPROFILE_MAX_CREDIT_EXPOSURE",
            SummaryType = "MaxValue",
            Label = "Maximum customer credit exposure",
            Severity = "Info",
            MetricValue = metricValue ?? 0,
            AffectedCount = 0,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCREDITPROFILE_MAX_CREDIT_EXPOSURE",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationClassificationTypeDistinctCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var metricValue = await _dbContext.CustomerClassifications
            .Select(x => x.ClassificationType)
            .Distinct()
            .CountAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerClassification",
            ColumnName = "ClassificationType",
            SummaryCode = "CUSTOMERCLASSIFICATION_TYPE_DISTINCT_COUNT",
            SummaryType = "DistinctCount",
            Label = "Distinct customer classification types",
            Severity = "Info",
            MetricValue = metricValue,
            AffectedCount = metricValue,
            HasDrilldown = false,
            DrilldownKey = "CUSTOMERCLASSIFICATION_TYPE_DISTINCT_COUNT",
            CreatedOn = DateTimeOffset.UtcNow
        };

        _dbContext.DataProfilingSummaries.Add(summary);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
