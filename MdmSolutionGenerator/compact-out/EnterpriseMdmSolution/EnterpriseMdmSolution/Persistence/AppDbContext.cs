using Microsoft.EntityFrameworkCore;
using EnterpriseMdmSolution.Analysis;
using EnterpriseMdmSolution.Entities;

namespace EnterpriseMdmSolution.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    public DbSet<CustomerContact> CustomerContacts => Set<CustomerContact>();
    public DbSet<CustomerBankAccount> CustomerBankAccounts => Set<CustomerBankAccount>();
    public DbSet<CustomerSalesArea> CustomerSalesAreas => Set<CustomerSalesArea>();
    public DbSet<CustomerTax> CustomerTaxs => Set<CustomerTax>();
    public DbSet<CustomerClassification> CustomerClassifications => Set<CustomerClassification>();
    public DbSet<CustomerCreditProfile> CustomerCreditProfiles => Set<CustomerCreditProfile>();
    public DbSet<CustomerPartnerFunction> CustomerPartnerFunctions => Set<CustomerPartnerFunction>();
    public DbSet<CustomerAttachment> CustomerAttachments => Set<CustomerAttachment>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<MaterialPlant> MaterialPlants => Set<MaterialPlant>();
    public DbSet<MaterialPrice> MaterialPrices => Set<MaterialPrice>();
    public DbSet<MaterialStorage> MaterialStorages => Set<MaterialStorage>();
    public DbSet<MaterialClassification> MaterialClassifications => Set<MaterialClassification>();
    public DbSet<MaterialVendor> MaterialVendors => Set<MaterialVendor>();
    public DbSet<MaterialUOM> MaterialUOMs => Set<MaterialUOM>();
    public DbSet<MaterialQualityInspection> MaterialQualityInspections => Set<MaterialQualityInspection>();
    public DbSet<MaterialForecast> MaterialForecasts => Set<MaterialForecast>();
    public DbSet<MaterialBarcode> MaterialBarcodes => Set<MaterialBarcode>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<VendorAddress> VendorAddresses => Set<VendorAddress>();
    public DbSet<VendorContact> VendorContacts => Set<VendorContact>();
    public DbSet<VendorBankAccount> VendorBankAccounts => Set<VendorBankAccount>();
    public DbSet<VendorTax> VendorTaxs => Set<VendorTax>();
    public DbSet<VendorPurchasingOrganization> VendorPurchasingOrganizations => Set<VendorPurchasingOrganization>();
    public DbSet<VendorCompliance> VendorCompliances => Set<VendorCompliance>();
    public DbSet<VendorEvaluation> VendorEvaluations => Set<VendorEvaluation>();
    public DbSet<VendorCertificate> VendorCertificates => Set<VendorCertificate>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<UnitOfMeasure> UnitOfMeasures => Set<UnitOfMeasure>();
    public DbSet<Plant> Plants => Set<Plant>();
    public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();
    public DbSet<MaterialGroup> MaterialGroups => Set<MaterialGroup>();
    public DbSet<SalesOrganization> SalesOrganizations => Set<SalesOrganization>();
    public DbSet<PurchasingOrganization> PurchasingOrganizations => Set<PurchasingOrganization>();
    public DbSet<PaymentTerm> PaymentTerms => Set<PaymentTerm>();
    public DbSet<BusinessObjectRun> BusinessObjectRuns => Set<BusinessObjectRun>();
    public DbSet<DataProfilingSummary> DataProfilingSummaries => Set<DataProfilingSummary>();
    public DbSet<DataProfilingDrilldown> DataProfilingDrilldowns => Set<DataProfilingDrilldown>();
    public DbSet<DataQualityRuleResult> DataQualityRuleResults => Set<DataQualityRuleResult>();
    public DbSet<DataQualityDrilldown> DataQualityDrilldowns => Set<DataQualityDrilldown>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditValues();
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerNumber).IsRequired().HasMaxLength(20);
            entity.HasIndex(x => x.CustomerNumber).IsUnique();
            entity.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.CustomerType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.Email).HasMaxLength(250);
            entity.Property(x => x.Phone).HasMaxLength(30);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
            entity.Property(x => x.IndustryCode).HasMaxLength(30);
            entity.HasIndex(x => x.IndustryCode);
            entity.Property(x => x.RiskCategory).HasMaxLength(30);
            entity.Property(x => x.RegistrationNumber).HasMaxLength(50);
            entity.Property(x => x.OnboardingDate);
            entity.Property(x => x.IsActive).IsRequired();
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.ToTable("CustomerAddresses");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.AddressType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.AddressLine1).IsRequired().HasMaxLength(200);
            entity.Property(x => x.AddressLine2).HasMaxLength(200);
            entity.Property(x => x.City).IsRequired().HasMaxLength(100);
            entity.Property(x => x.State).HasMaxLength(100);
            entity.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.Region).HasMaxLength(100);
            entity.Property(x => x.Latitude).HasPrecision(18, 4);
            entity.Property(x => x.Longitude).HasPrecision(18, 4);
            entity.Property(x => x.IsDefault).IsRequired();
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.ToTable("CustomerContacts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Email).HasMaxLength(250);
            entity.Property(x => x.Phone).HasMaxLength(30);
            entity.Property(x => x.MobilePhone).HasMaxLength(30);
            entity.Property(x => x.Designation).HasMaxLength(100);
            entity.Property(x => x.Department).HasMaxLength(100);
            entity.Property(x => x.PreferredLanguage).HasMaxLength(20);
            entity.Property(x => x.IsPrimary).IsRequired();
        });

        modelBuilder.Entity<CustomerBankAccount>(entity =>
        {
            entity.ToTable("CustomerBankAccounts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.BankName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.AccountNumber).IsRequired().HasMaxLength(50);
            entity.Property(x => x.IfscCode).HasMaxLength(20);
            entity.Property(x => x.SwiftCode).HasMaxLength(20);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
            entity.Property(x => x.AccountHolderName).HasMaxLength(150);
            entity.Property(x => x.BankCountryId);
            entity.HasIndex(x => x.BankCountryId);
            entity.Property(x => x.IsDefault).IsRequired();
        });

        modelBuilder.Entity<CustomerSalesArea>(entity =>
        {
            entity.ToTable("CustomerSalesAreas");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.SalesOrganizationId).IsRequired();
            entity.HasIndex(x => x.SalesOrganizationId);
            entity.Property(x => x.DistributionChannel).IsRequired().HasMaxLength(30);
            entity.Property(x => x.Division).IsRequired().HasMaxLength(30);
            entity.Property(x => x.PaymentTermId);
            entity.HasIndex(x => x.PaymentTermId);
            entity.Property(x => x.CreditLimit).HasPrecision(18, 4);
            entity.Property(x => x.CustomerGroup).HasMaxLength(50);
            entity.Property(x => x.SalesOffice).HasMaxLength(50);
            entity.Property(x => x.SalesDistrict).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerTax>(entity =>
        {
            entity.ToTable("CustomerTaxs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.TaxType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.TaxNumber).IsRequired().HasMaxLength(50);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.ValidFrom);
            entity.Property(x => x.ValidTo);
            entity.Property(x => x.IsExempt).IsRequired();
        });

        modelBuilder.Entity<CustomerClassification>(entity =>
        {
            entity.ToTable("CustomerClassifications");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.ClassificationType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.ClassificationValue).IsRequired().HasMaxLength(100);
            entity.Property(x => x.ClassificationGroup).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerCreditProfile>(entity =>
        {
            entity.ToTable("CustomerCreditProfiles");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.CreditControlArea).IsRequired().HasMaxLength(20);
            entity.Property(x => x.CreditLimit).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.CreditExposure).HasPrecision(18, 4);
            entity.Property(x => x.CreditRiskClass).HasMaxLength(30);
            entity.Property(x => x.ReviewDate);
            entity.Property(x => x.IsBlocked).IsRequired();
        });

        modelBuilder.Entity<CustomerPartnerFunction>(entity =>
        {
            entity.ToTable("CustomerPartnerFunctions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.PartnerFunctionCode).IsRequired().HasMaxLength(20);
            entity.Property(x => x.PartnerCustomerId);
            entity.HasIndex(x => x.PartnerCustomerId);
            entity.Property(x => x.Description).HasMaxLength(200);
            entity.Property(x => x.IsDefault).IsRequired();
        });

        modelBuilder.Entity<CustomerAttachment>(entity =>
        {
            entity.ToTable("CustomerAttachments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.CustomerId).IsRequired();
            entity.HasIndex(x => x.CustomerId);
            entity.Property(x => x.DocumentType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.FileName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.ContentType).HasMaxLength(100);
            entity.Property(x => x.StoragePath).IsRequired().HasMaxLength(500);
            entity.Property(x => x.UploadedOn).IsRequired();
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Materials");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialNumber).IsRequired().HasMaxLength(40);
            entity.HasIndex(x => x.MaterialNumber).IsUnique();
            entity.Property(x => x.MaterialName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.MaterialType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.MaterialGroupId).IsRequired();
            entity.HasIndex(x => x.MaterialGroupId);
            entity.Property(x => x.BaseUnitOfMeasureId).IsRequired();
            entity.HasIndex(x => x.BaseUnitOfMeasureId);
            entity.Property(x => x.GlobalTradeItemNumber).HasMaxLength(50);
            entity.HasIndex(x => x.GlobalTradeItemNumber);
            entity.Property(x => x.ProductHierarchy).HasMaxLength(50);
            entity.Property(x => x.GrossWeight).HasPrecision(18, 4);
            entity.Property(x => x.NetWeight).HasPrecision(18, 4);
            entity.Property(x => x.WeightUnitOfMeasureId);
            entity.HasIndex(x => x.WeightUnitOfMeasureId);
            entity.Property(x => x.IsBatchManaged).IsRequired();
            entity.Property(x => x.IsSerialManaged).IsRequired();
            entity.Property(x => x.IsActive).IsRequired();
        });

        modelBuilder.Entity<MaterialPlant>(entity =>
        {
            entity.ToTable("MaterialPlants");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.PlantId).IsRequired();
            entity.HasIndex(x => x.PlantId);
            entity.Property(x => x.ProcurementType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.ReorderPoint).HasPrecision(18, 4);
            entity.Property(x => x.MinimumLotSize).HasPrecision(18, 4);
            entity.Property(x => x.MaximumLotSize).HasPrecision(18, 4);
            entity.Property(x => x.MrpType).HasMaxLength(20);
            entity.Property(x => x.PlanningTimeFenceDays);
            entity.Property(x => x.ProfitCenter).HasMaxLength(50);
        });

        modelBuilder.Entity<MaterialPrice>(entity =>
        {
            entity.ToTable("MaterialPrices");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
            entity.Property(x => x.PriceType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.Price).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.PriceUnit).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.ValidFrom).IsRequired();
            entity.Property(x => x.ValidTo);
            entity.Property(x => x.SourceSystem).HasMaxLength(50);
        });

        modelBuilder.Entity<MaterialStorage>(entity =>
        {
            entity.ToTable("MaterialStorages");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.StorageLocationId).IsRequired();
            entity.HasIndex(x => x.StorageLocationId);
            entity.Property(x => x.BinLocation).HasMaxLength(50);
            entity.Property(x => x.SafetyStock).HasPrecision(18, 4);
            entity.Property(x => x.MaximumStock).HasPrecision(18, 4);
            entity.Property(x => x.TemperatureZone).HasMaxLength(30);
            entity.Property(x => x.HazardousStorageRequired);
        });

        modelBuilder.Entity<MaterialClassification>(entity =>
        {
            entity.ToTable("MaterialClassifications");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.ClassType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.ClassValue).IsRequired().HasMaxLength(100);
            entity.Property(x => x.CharacteristicName).HasMaxLength(100);
        });

        modelBuilder.Entity<MaterialVendor>(entity =>
        {
            entity.ToTable("MaterialVendors");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.VendorMaterialNumber).HasMaxLength(50);
            entity.Property(x => x.LeadTimeDays);
            entity.Property(x => x.MinimumOrderQuantity).HasPrecision(18, 4);
            entity.Property(x => x.PurchaseUnitOfMeasureId);
            entity.HasIndex(x => x.PurchaseUnitOfMeasureId);
            entity.Property(x => x.IsPreferred).IsRequired();
        });

        modelBuilder.Entity<MaterialUOM>(entity =>
        {
            entity.ToTable("MaterialUOMs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.UnitOfMeasureId).IsRequired();
            entity.HasIndex(x => x.UnitOfMeasureId);
            entity.Property(x => x.ConversionNumerator).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.ConversionDenominator).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.Barcode).HasMaxLength(50);
            entity.Property(x => x.IsBaseUnit).IsRequired();
        });

        modelBuilder.Entity<MaterialQualityInspection>(entity =>
        {
            entity.ToTable("MaterialQualityInspections");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.InspectionType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.InspectionIntervalDays);
            entity.Property(x => x.QualityCertificateRequired).IsRequired();
            entity.Property(x => x.SampleSize).HasPrecision(18, 4);
            entity.Property(x => x.AcceptanceCriteria).HasMaxLength(500);
        });

        modelBuilder.Entity<MaterialForecast>(entity =>
        {
            entity.ToTable("MaterialForecasts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.PlantId).IsRequired();
            entity.HasIndex(x => x.PlantId);
            entity.Property(x => x.ForecastPeriod).IsRequired().HasMaxLength(20);
            entity.Property(x => x.ForecastQuantity).IsRequired().HasPrecision(18, 4);
            entity.Property(x => x.ForecastUnitOfMeasureId).IsRequired();
            entity.HasIndex(x => x.ForecastUnitOfMeasureId);
            entity.Property(x => x.ConfidencePercent).HasPrecision(18, 4);
        });

        modelBuilder.Entity<MaterialBarcode>(entity =>
        {
            entity.ToTable("MaterialBarcodes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.MaterialId).IsRequired();
            entity.HasIndex(x => x.MaterialId);
            entity.Property(x => x.BarcodeType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.BarcodeValue).IsRequired().HasMaxLength(100);
            entity.HasIndex(x => x.BarcodeValue).IsUnique();
            entity.Property(x => x.UnitOfMeasureId);
            entity.HasIndex(x => x.UnitOfMeasureId);
            entity.Property(x => x.IsPrimary).IsRequired();
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("Vendors");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorNumber).IsRequired().HasMaxLength(20);
            entity.HasIndex(x => x.VendorNumber).IsUnique();
            entity.Property(x => x.VendorName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.VendorType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.Email).HasMaxLength(250);
            entity.Property(x => x.Phone).HasMaxLength(30);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
            entity.Property(x => x.PaymentTermId);
            entity.HasIndex(x => x.PaymentTermId);
            entity.Property(x => x.SupplierCategory).HasMaxLength(50);
            entity.Property(x => x.DunsNumber).HasMaxLength(30);
            entity.HasIndex(x => x.DunsNumber);
            entity.Property(x => x.OnboardingStatus).HasMaxLength(30);
            entity.Property(x => x.OnboardingDate);
            entity.Property(x => x.IsActive).IsRequired();
        });

        modelBuilder.Entity<VendorAddress>(entity =>
        {
            entity.ToTable("VendorAddresses");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.AddressType).IsRequired().HasMaxLength(30);
            entity.Property(x => x.AddressLine1).IsRequired().HasMaxLength(200);
            entity.Property(x => x.AddressLine2).HasMaxLength(200);
            entity.Property(x => x.City).IsRequired().HasMaxLength(100);
            entity.Property(x => x.State).HasMaxLength(100);
            entity.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.Region).HasMaxLength(100);
            entity.Property(x => x.IsDefault).IsRequired();
        });

        modelBuilder.Entity<VendorContact>(entity =>
        {
            entity.ToTable("VendorContacts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Email).HasMaxLength(250);
            entity.Property(x => x.Phone).HasMaxLength(30);
            entity.Property(x => x.MobilePhone).HasMaxLength(30);
            entity.Property(x => x.Designation).HasMaxLength(100);
            entity.Property(x => x.Department).HasMaxLength(100);
            entity.Property(x => x.IsPrimary).IsRequired();
        });

        modelBuilder.Entity<VendorBankAccount>(entity =>
        {
            entity.ToTable("VendorBankAccounts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.BankName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.AccountNumber).IsRequired().HasMaxLength(50);
            entity.Property(x => x.IfscCode).HasMaxLength(20);
            entity.Property(x => x.SwiftCode).HasMaxLength(20);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
            entity.Property(x => x.AccountHolderName).HasMaxLength(150);
            entity.Property(x => x.BankCountryId);
            entity.HasIndex(x => x.BankCountryId);
            entity.Property(x => x.IsDefault).IsRequired();
        });

        modelBuilder.Entity<VendorTax>(entity =>
        {
            entity.ToTable("VendorTaxs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.TaxType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.TaxNumber).IsRequired().HasMaxLength(50);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
            entity.Property(x => x.ValidFrom);
            entity.Property(x => x.ValidTo);
            entity.Property(x => x.IsTaxWithholdingApplicable);
        });

        modelBuilder.Entity<VendorPurchasingOrganization>(entity =>
        {
            entity.ToTable("VendorPurchasingOrganizations");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.PurchasingOrganizationId).IsRequired();
            entity.HasIndex(x => x.PurchasingOrganizationId);
            entity.Property(x => x.PaymentTermId);
            entity.HasIndex(x => x.PaymentTermId);
            entity.Property(x => x.Incoterms).HasMaxLength(30);
            entity.Property(x => x.OrderCurrencyId);
            entity.HasIndex(x => x.OrderCurrencyId);
            entity.Property(x => x.PurchaseGroup).HasMaxLength(50);
            entity.Property(x => x.MinimumOrderValue).HasPrecision(18, 4);
            entity.Property(x => x.IsBlockedForPurchasing).IsRequired();
        });

        modelBuilder.Entity<VendorCompliance>(entity =>
        {
            entity.ToTable("VendorCompliances");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.ComplianceType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.ComplianceStatus).IsRequired().HasMaxLength(30);
            entity.Property(x => x.CertificateNumber).HasMaxLength(100);
            entity.Property(x => x.ValidFrom);
            entity.Property(x => x.ValidTo);
            entity.Property(x => x.ReviewOwner).HasMaxLength(100);
        });

        modelBuilder.Entity<VendorEvaluation>(entity =>
        {
            entity.ToTable("VendorEvaluations");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.EvaluationPeriod).IsRequired().HasMaxLength(20);
            entity.Property(x => x.QualityScore).HasPrecision(18, 4);
            entity.Property(x => x.DeliveryScore).HasPrecision(18, 4);
            entity.Property(x => x.CostScore).HasPrecision(18, 4);
            entity.Property(x => x.OverallScore).HasPrecision(18, 4);
            entity.Property(x => x.EvaluationDate).IsRequired();
        });

        modelBuilder.Entity<VendorCertificate>(entity =>
        {
            entity.ToTable("VendorCertificates");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.VendorId).IsRequired();
            entity.HasIndex(x => x.VendorId);
            entity.Property(x => x.CertificateType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.CertificateName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.CertificateNumber).HasMaxLength(100);
            entity.Property(x => x.IssuingAuthority).HasMaxLength(150);
            entity.Property(x => x.ExpiryDate);
            entity.Property(x => x.StoragePath).HasMaxLength(500);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Countries");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(3);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currencies");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(3);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.DecimalPlaces).IsRequired();
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.ToTable("UnitOfMeasures");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(10);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Dimension).HasMaxLength(50);
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.ToTable("Plants");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.PlantCode).IsRequired().HasMaxLength(10);
            entity.HasIndex(x => x.PlantCode).IsUnique();
            entity.Property(x => x.PlantName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.CountryId).IsRequired();
            entity.HasIndex(x => x.CountryId);
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.ToTable("StorageLocations");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.StorageLocationCode).IsRequired().HasMaxLength(10);
            entity.Property(x => x.StorageLocationName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.PlantId).IsRequired();
            entity.HasIndex(x => x.PlantId);
        });

        modelBuilder.Entity<MaterialGroup>(entity =>
        {
            entity.ToTable("MaterialGroups");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(20);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<SalesOrganization>(entity =>
        {
            entity.ToTable("SalesOrganizations");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.SalesOrganizationCode).IsRequired().HasMaxLength(10);
            entity.HasIndex(x => x.SalesOrganizationCode).IsUnique();
            entity.Property(x => x.SalesOrganizationName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
        });

        modelBuilder.Entity<PurchasingOrganization>(entity =>
        {
            entity.ToTable("PurchasingOrganizations");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.PurchasingOrganizationCode).IsRequired().HasMaxLength(10);
            entity.HasIndex(x => x.PurchasingOrganizationCode).IsUnique();
            entity.Property(x => x.PurchasingOrganizationName).IsRequired().HasMaxLength(150);
            entity.Property(x => x.CurrencyId).IsRequired();
            entity.HasIndex(x => x.CurrencyId);
        });

        modelBuilder.Entity<PaymentTerm>(entity =>
        {
            entity.ToTable("PaymentTerms");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(20);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Description).IsRequired().HasMaxLength(200);
            entity.Property(x => x.NetDays).IsRequired();
        });

        modelBuilder.Entity<Customer>().HasOne(x => x.Country).WithMany(x => x.Customers).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Customer>().HasOne(x => x.Currency).WithMany(x => x.Customers).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerAddress>().HasOne(x => x.Customer).WithMany(x => x.CustomerAddresses).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerAddress>().HasOne(x => x.Country).WithMany(x => x.CustomerAddresses).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerContact>().HasOne(x => x.Customer).WithMany(x => x.CustomerContacts).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerBankAccount>().HasOne(x => x.Customer).WithMany(x => x.CustomerBankAccounts).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerBankAccount>().HasOne(x => x.Currency).WithMany(x => x.CustomerBankAccounts).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerBankAccount>().HasOne(x => x.Country).WithMany(x => x.CustomerBankAccounts).HasForeignKey(x => x.BankCountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerSalesArea>().HasOne(x => x.Customer).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerSalesArea>().HasOne(x => x.SalesOrganization).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.SalesOrganizationId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerSalesArea>().HasOne(x => x.PaymentTerm).WithMany(x => x.CustomerSalesAreas).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerTax>().HasOne(x => x.Customer).WithMany(x => x.CustomerTaxs).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerTax>().HasOne(x => x.Country).WithMany(x => x.CustomerTaxs).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerClassification>().HasOne(x => x.Customer).WithMany(x => x.CustomerClassifications).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerCreditProfile>().HasOne(x => x.Customer).WithMany(x => x.CustomerCreditProfiles).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerPartnerFunction>().HasOne(x => x.Customer).WithMany(x => x.CustomerPartnerFunctions).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<CustomerAttachment>().HasOne(x => x.Customer).WithMany(x => x.CustomerAttachments).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Material>().HasOne(x => x.MaterialGroup).WithMany(x => x.Materials).HasForeignKey(x => x.MaterialGroupId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Material>().HasOne(x => x.UnitOfMeasure).WithMany(x => x.Materials).HasForeignKey(x => x.BaseUnitOfMeasureId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialPlant>().HasOne(x => x.Material).WithMany(x => x.MaterialPlants).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialPlant>().HasOne(x => x.Plant).WithMany(x => x.MaterialPlants).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialPrice>().HasOne(x => x.Material).WithMany(x => x.MaterialPrices).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialPrice>().HasOne(x => x.Currency).WithMany(x => x.MaterialPrices).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialStorage>().HasOne(x => x.Material).WithMany(x => x.MaterialStorages).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialStorage>().HasOne(x => x.StorageLocation).WithMany(x => x.MaterialStorages).HasForeignKey(x => x.StorageLocationId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialClassification>().HasOne(x => x.Material).WithMany(x => x.MaterialClassifications).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialVendor>().HasOne(x => x.Material).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialVendor>().HasOne(x => x.Vendor).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialVendor>().HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialVendors).HasForeignKey(x => x.PurchaseUnitOfMeasureId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialUOM>().HasOne(x => x.Material).WithMany(x => x.MaterialUOMs).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialUOM>().HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialUOMs).HasForeignKey(x => x.UnitOfMeasureId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialQualityInspection>().HasOne(x => x.Material).WithMany(x => x.MaterialQualityInspections).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialForecast>().HasOne(x => x.Material).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialForecast>().HasOne(x => x.Plant).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialForecast>().HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialForecasts).HasForeignKey(x => x.ForecastUnitOfMeasureId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialBarcode>().HasOne(x => x.Material).WithMany(x => x.MaterialBarcodes).HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<MaterialBarcode>().HasOne(x => x.UnitOfMeasure).WithMany(x => x.MaterialBarcodes).HasForeignKey(x => x.UnitOfMeasureId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Vendor>().HasOne(x => x.Country).WithMany(x => x.Vendors).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Vendor>().HasOne(x => x.Currency).WithMany(x => x.Vendors).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Vendor>().HasOne(x => x.PaymentTerm).WithMany(x => x.Vendors).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorAddress>().HasOne(x => x.Vendor).WithMany(x => x.VendorAddresses).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorAddress>().HasOne(x => x.Country).WithMany(x => x.VendorAddresses).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorContact>().HasOne(x => x.Vendor).WithMany(x => x.VendorContacts).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorBankAccount>().HasOne(x => x.Vendor).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorBankAccount>().HasOne(x => x.Currency).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorBankAccount>().HasOne(x => x.Country).WithMany(x => x.VendorBankAccounts).HasForeignKey(x => x.BankCountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorTax>().HasOne(x => x.Vendor).WithMany(x => x.VendorTaxs).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorTax>().HasOne(x => x.Country).WithMany(x => x.VendorTaxs).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorPurchasingOrganization>().HasOne(x => x.Vendor).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorPurchasingOrganization>().HasOne(x => x.PurchasingOrganization).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.PurchasingOrganizationId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorPurchasingOrganization>().HasOne(x => x.PaymentTerm).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorPurchasingOrganization>().HasOne(x => x.Currency).WithMany(x => x.VendorPurchasingOrganizations).HasForeignKey(x => x.OrderCurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorCompliance>().HasOne(x => x.Vendor).WithMany(x => x.VendorCompliances).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorEvaluation>().HasOne(x => x.Vendor).WithMany(x => x.VendorEvaluations).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VendorCertificate>().HasOne(x => x.Vendor).WithMany(x => x.VendorCertificates).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Plant>().HasOne(x => x.Country).WithMany(x => x.Plants).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<StorageLocation>().HasOne(x => x.Plant).WithMany(x => x.StorageLocations).HasForeignKey(x => x.PlantId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<SalesOrganization>().HasOne(x => x.Currency).WithMany(x => x.SalesOrganizations).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<PurchasingOrganization>().HasOne(x => x.Currency).WithMany(x => x.PurchasingOrganizations).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BusinessObjectRun>().HasKey(x => x.RunId);
        modelBuilder.Entity<DataProfilingSummary>().HasKey(x => x.SummaryId);
        modelBuilder.Entity<DataProfilingDrilldown>().HasKey(x => x.DrilldownId);
        modelBuilder.Entity<DataQualityRuleResult>().HasKey(x => x.ResultId);
        modelBuilder.Entity<DataQualityDrilldown>().HasKey(x => x.DrilldownId);
    }

    private void ApplyAuditValues()
    {
        var now = DateTimeOffset.UtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = now;
                entry.Entity.CreatedBy ??= "system";
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = now;
                entry.Entity.ModifiedBy ??= "system";
            }
        }
    }
}