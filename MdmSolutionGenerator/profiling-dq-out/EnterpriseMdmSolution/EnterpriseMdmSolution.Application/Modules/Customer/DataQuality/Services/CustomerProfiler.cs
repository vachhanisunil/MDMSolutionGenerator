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
        await ProfileCustomerCustomerNumberNullCountAsync(runId, cancellationToken);
        await ProfileCustomerCustomerNameNullCountAsync(runId, cancellationToken);
        await ProfileCustomerCustomerTypeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressAddressTypeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressAddressLine1NullCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressCityNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAddressPostalCodeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerContactFirstNameNullCountAsync(runId, cancellationToken);
        await ProfileCustomerContactLastNameNullCountAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountBankNameNullCountAsync(runId, cancellationToken);
        await ProfileCustomerBankAccountAccountNumberNullCountAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaDistributionChannelNullCountAsync(runId, cancellationToken);
        await ProfileCustomerSalesAreaDivisionNullCountAsync(runId, cancellationToken);
        await ProfileCustomerTaxTaxTypeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerTaxTaxNumberNullCountAsync(runId, cancellationToken);
        await ProfileCustomerClassificationClassificationTypeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerClassificationClassificationValueNullCountAsync(runId, cancellationToken);
        await ProfileCustomerCreditProfileCreditControlAreaNullCountAsync(runId, cancellationToken);
        await ProfileCustomerPartnerFunctionPartnerFunctionCodeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentDocumentTypeNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentFileNameNullCountAsync(runId, cancellationToken);
        await ProfileCustomerAttachmentStoragePathNullCountAsync(runId, cancellationToken);
    }

    private async Task ProfileCustomerCustomerNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Customer CustomerNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMER_CUSTOMERNUMBER_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "Customer",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CustomerNumber",
                SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CustomerNumber,
                Message = "Customer CustomerNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Customer CustomerName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMER_CUSTOMERNAME_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "Customer",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CustomerName",
                SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CustomerName,
                Message = "Customer CustomerName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCustomerTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "Customer CustomerType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMER_CUSTOMERTYPE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "Customer",
                RootRecordId = x.Id.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CustomerType",
                SummaryCode = "CUSTOMER_CUSTOMER_CUSTOMERTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CustomerType,
                Message = "Customer CustomerType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressAddressTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERADDRESS_ADDRESSTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAddress AddressType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERADDRESS_ADDRESSTYPE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAddress",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "AddressType",
                SummaryCode = "CUSTOMER_CUSTOMERADDRESS_ADDRESSTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AddressType,
                Message = "CustomerAddress AddressType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressAddressLine1NullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERADDRESS_ADDRESSLINE1_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAddress AddressLine1 missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERADDRESS_ADDRESSLINE1_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAddress",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "AddressLine1",
                SummaryCode = "CUSTOMER_CUSTOMERADDRESS_ADDRESSLINE1_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AddressLine1,
                Message = "CustomerAddress AddressLine1 missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AddressLine1 }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressCityNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERADDRESS_CITY_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAddress City missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERADDRESS_CITY_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAddress",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "City",
                SummaryCode = "CUSTOMER_CUSTOMERADDRESS_CITY_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.City,
                Message = "CustomerAddress City missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.City }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAddressPostalCodeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERADDRESS_POSTALCODE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAddress PostalCode missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERADDRESS_POSTALCODE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAddress",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "PostalCode",
                SummaryCode = "CUSTOMER_CUSTOMERADDRESS_POSTALCODE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.PostalCode,
                Message = "CustomerAddress PostalCode missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PostalCode }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactFirstNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERCONTACT_FIRSTNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerContact FirstName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERCONTACT_FIRSTNAME_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerContact",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "FirstName",
                SummaryCode = "CUSTOMER_CUSTOMERCONTACT_FIRSTNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.FirstName,
                Message = "CustomerContact FirstName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FirstName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerContactLastNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERCONTACT_LASTNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerContact LastName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERCONTACT_LASTNAME_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerContact",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "LastName",
                SummaryCode = "CUSTOMER_CUSTOMERCONTACT_LASTNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.LastName,
                Message = "CustomerContact LastName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.LastName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountBankNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERBANKACCOUNT_BANKNAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerBankAccount BankName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERBANKACCOUNT_BANKNAME_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerBankAccount",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "BankName",
                SummaryCode = "CUSTOMER_CUSTOMERBANKACCOUNT_BANKNAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.BankName,
                Message = "CustomerBankAccount BankName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.BankName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerBankAccountAccountNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerBankAccount AccountNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerBankAccount",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "AccountNumber",
                SummaryCode = "CUSTOMER_CUSTOMERBANKACCOUNT_ACCOUNTNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.AccountNumber,
                Message = "CustomerBankAccount AccountNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.AccountNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaDistributionChannelNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.DistributionChannel))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "DistributionChannel",
            SummaryCode = "CUSTOMER_CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerSalesArea DistributionChannel missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerSalesArea",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "DistributionChannel",
                SummaryCode = "CUSTOMER_CUSTOMERSALESAREA_DISTRIBUTIONCHANNEL_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.DistributionChannel,
                Message = "CustomerSalesArea DistributionChannel missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DistributionChannel }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerSalesAreaDivisionNullCountAsync(Guid runId, CancellationToken cancellationToken)
    {
        var totalRecords = await _dbContext.CustomerSalesAreas.CountAsync(cancellationToken);
        var affectedSourceRecords = await _dbContext.CustomerSalesAreas
            .Where(x => string.IsNullOrEmpty(x.Division))
            .ToListAsync(cancellationToken);

        var summary = new DataProfilingSummary
        {
            SummaryId = Guid.NewGuid(),
            RunId = runId,
            BusinessObjectName = "Customer",
            EntityName = "CustomerSalesArea",
            ColumnName = "Division",
            SummaryCode = "CUSTOMER_CUSTOMERSALESAREA_DIVISION_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerSalesArea Division missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERSALESAREA_DIVISION_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerSalesArea",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "Division",
                SummaryCode = "CUSTOMER_CUSTOMERSALESAREA_DIVISION_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.Division,
                Message = "CustomerSalesArea Division missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.Division }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxTaxTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERTAX_TAXTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerTax TaxType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERTAX_TAXTYPE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerTax",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "TaxType",
                SummaryCode = "CUSTOMER_CUSTOMERTAX_TAXTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.TaxType,
                Message = "CustomerTax TaxType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerTaxTaxNumberNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERTAX_TAXNUMBER_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerTax TaxNumber missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERTAX_TAXNUMBER_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerTax",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "TaxNumber",
                SummaryCode = "CUSTOMER_CUSTOMERTAX_TAXNUMBER_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.TaxNumber,
                Message = "CustomerTax TaxNumber missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.TaxNumber }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationClassificationTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerClassification ClassificationType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerClassification",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ClassificationType",
                SummaryCode = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ClassificationType,
                Message = "CustomerClassification ClassificationType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerClassificationClassificationValueNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerClassification ClassificationValue missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerClassification",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "ClassificationValue",
                SummaryCode = "CUSTOMER_CUSTOMERCLASSIFICATION_CLASSIFICATIONVALUE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.ClassificationValue,
                Message = "CustomerClassification ClassificationValue missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.ClassificationValue }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerCreditProfileCreditControlAreaNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerCreditProfile CreditControlArea missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerCreditProfile",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "CreditControlArea",
                SummaryCode = "CUSTOMER_CUSTOMERCREDITPROFILE_CREDITCONTROLAREA_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.CreditControlArea,
                Message = "CustomerCreditProfile CreditControlArea missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.CreditControlArea }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerPartnerFunctionPartnerFunctionCodeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerPartnerFunction PartnerFunctionCode missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerPartnerFunction",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "PartnerFunctionCode",
                SummaryCode = "CUSTOMER_CUSTOMERPARTNERFUNCTION_PARTNERFUNCTIONCODE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.PartnerFunctionCode,
                Message = "CustomerPartnerFunction PartnerFunctionCode missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.PartnerFunctionCode }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentDocumentTypeNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_DOCUMENTTYPE_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAttachment DocumentType missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERATTACHMENT_DOCUMENTTYPE_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAttachment",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "DocumentType",
                SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_DOCUMENTTYPE_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.DocumentType,
                Message = "CustomerAttachment DocumentType missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.DocumentType }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentFileNameNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_FILENAME_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAttachment FileName missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERATTACHMENT_FILENAME_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAttachment",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "FileName",
                SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_FILENAME_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.FileName,
                Message = "CustomerAttachment FileName missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.FileName }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task ProfileCustomerAttachmentStoragePathNullCountAsync(Guid runId, CancellationToken cancellationToken)
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
            SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_STORAGEPATH_NULL_COUNT",
            SummaryType = "NullCount",
            Label = "CustomerAttachment StoragePath missing count",
            Severity = "Medium",
            MetricValue = affectedSourceRecords.Count,
            AffectedCount = affectedSourceRecords.Count,
            HasDrilldown = true,
            DrilldownKey = "CUSTOMER_CUSTOMERATTACHMENT_STORAGEPATH_NULL_COUNT",
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
                BusinessObjectName = "Customer",
                EntityName = "CustomerAttachment",
                RootRecordId = x.CustomerId.ToString(),
                RecordId = x.Id.ToString(),
                ColumnName = "StoragePath",
                SummaryCode = "CUSTOMER_CUSTOMERATTACHMENT_STORAGEPATH_NULL_COUNT",
                SummaryType = "NullCount",
                FieldValue = x.StoragePath,
                Message = "CustomerAttachment StoragePath missing count",
                RecordSnapshotJson = JsonSerializer.Serialize(new { x.Id, x.CustomerId, x.StoragePath }),
                CreatedOn = DateTimeOffset.UtcNow
            }).ToList();

            _dbContext.DataProfilingDrilldowns.AddRange(affectedRecords);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
