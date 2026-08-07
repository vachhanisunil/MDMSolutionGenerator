using CustomerNdjsonGenerator.Api.Models;

namespace CustomerNdjsonGenerator.Api.Services;

public static class CustomerBusinessObjectFactory
{
    public static CustomerBusinessObject Create(long sequence, CustomerNdjsonGenerationRequest request)
    {
        var customerNumber = $"CUST-{sequence:D8}";
        var customerSlug = $"customer-{sequence:D8}";
        var customerName = $"Acme Manufacturing Unit {sequence:D8} Pvt Ltd";
        var city = Pick(sequence, "Mumbai", "Pune", "Bengaluru", "Chennai", "Hyderabad", "Delhi");
        var state = Pick(sequence, "Maharashtra", "Maharashtra", "Karnataka", "Tamil Nadu", "Telangana", "Delhi");
        var region = Pick(sequence, "West", "West", "South", "South", "South", "North");
        var firstName = Pick(sequence, "Raj", "Asha", "Vikram", "Neha", "Arjun", "Priya");
        var lastName = Pick(sequence, "Mehta", "Sharma", "Rao", "Iyer", "Patel", "Nair");
        var creditLimit = 250000m + sequence % 10 * 50000m;

        return new CustomerBusinessObject
        {
            CustomerNumber = customerNumber,
            CustomerName = customerName,
            CustomerType = Pick(sequence, "Corporate", "Enterprise", "Distributor"),
            Email = $"accounts+{customerSlug}@acme.example.com",
            Phone = $"+91-{9000000000 + sequence % 1_000_000_000:D10}",
            CountryId = request.CountryId,
            CurrencyId = request.CurrencyId,
            IndustryCode = Pick(sequence, "MFG", "AUTO", "PHARMA", "FMCG"),
            RiskCategory = Pick(sequence, "Low", "Medium", "High"),
            RegistrationNumber = $"REG-ACME-{sequence:D8}",
            OnboardingDate = Utc(2026, 7, 13).AddDays(sequence % 365),
            IsActive = sequence % 20 != 0,
            CustomerAddresses =
            [
                new CustomerAddress
                {
                    CustomerId = 0,
                    AddressType = "Billing",
                    AddressLine1 = $"Plot {sequence % 9000 + 1}, Industrial Estate",
                    AddressLine2 = $"Phase {sequence % 5 + 1}",
                    City = city,
                    State = state,
                    PostalCode = $"{400000 + sequence % 99999:D6}",
                    CountryId = request.CountryId,
                    Region = region,
                    Latitude = 18.9000m + sequence % 1000 / 10000m,
                    Longitude = 72.8000m + sequence % 1000 / 10000m,
                    IsDefault = true
                }
            ],
            CustomerContacts =
            [
                new CustomerContact
                {
                    CustomerId = 0,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = $"{firstName.ToLowerInvariant()}.{lastName.ToLowerInvariant()}.{sequence:D8}@acme.example.com",
                    Phone = $"+91-{2200000000 + sequence % 1_000_000_000:D10}",
                    MobilePhone = $"+91-{9800000000 + sequence % 100_000_000:D10}",
                    Designation = Pick(sequence, "Purchase Manager", "Finance Manager", "Operations Lead"),
                    Department = Pick(sequence, "Procurement", "Finance", "Operations"),
                    PreferredLanguage = Pick(sequence, "English", "Hindi", "Marathi", "Tamil"),
                    IsPrimary = true
                }
            ],
            CustomerBankAccounts =
            [
                new CustomerBankAccount
                {
                    CustomerId = 0,
                    BankName = Pick(sequence, "State Bank of India", "HDFC Bank", "ICICI Bank", "Axis Bank"),
                    AccountNumber = $"{10_000_000_000 + sequence:D12}",
                    IfscCode = $"SBIN{sequence % 10_000_000:D7}",
                    SwiftCode = "SBININBBXXX",
                    CurrencyId = request.CurrencyId,
                    AccountHolderName = customerName,
                    BankCountryId = request.CountryId,
                    IsDefault = true
                }
            ],
            CustomerSalesAreas =
            [
                new CustomerSalesArea
                {
                    CustomerId = 0,
                    SalesOrganizationId = request.SalesOrganizationId,
                    DistributionChannel = Pick(sequence, "Direct", "Partner", "Online"),
                    Division = Pick(sequence, "Industrial", "Retail", "Healthcare"),
                    PaymentTermId = request.PaymentTermId,
                    CreditLimit = creditLimit,
                    CustomerGroup = Pick(sequence, "Enterprise", "Strategic", "Growth"),
                    SalesOffice = city,
                    SalesDistrict = region
                }
            ],
            CustomerTaxs =
            [
                new CustomerTax
                {
                    CustomerId = 0,
                    TaxType = "GST",
                    TaxNumber = $"27ABCDE{sequence:D8}F1Z{sequence % 10}",
                    CountryId = request.CountryId,
                    ValidFrom = Utc(2026, 1, 1),
                    ValidTo = Utc(2026, 12, 31),
                    IsExempt = false
                }
            ],
            CustomerClassifications =
            [
                new CustomerClassification
                {
                    CustomerId = 0,
                    ClassificationType = "Segment",
                    ClassificationValue = Pick(sequence, "Strategic", "Preferred", "Standard"),
                    ClassificationGroup = "Customer Segmentation"
                }
            ],
            CustomerCreditProfiles =
            [
                new CustomerCreditProfile
                {
                    CustomerId = 0,
                    CreditControlArea = "IN01",
                    CreditLimit = creditLimit,
                    CreditExposure = 50000m + sequence % 10 * 25000m,
                    CreditRiskClass = Pick(sequence, "Low", "Medium", "High"),
                    ReviewDate = Utc(2026, 12, 31),
                    IsBlocked = sequence % 50 == 0
                }
            ],
            CustomerPartnerFunctions =
            [
                new CustomerPartnerFunction
                {
                    CustomerId = 0,
                    PartnerFunctionCode = "SP",
                    PartnerCustomerId = null,
                    Description = "Sold-to party",
                    IsDefault = true
                }
            ],
            CustomerAttachments =
            [
                new CustomerAttachment
                {
                    CustomerId = 0,
                    DocumentType = "GST Certificate",
                    FileName = $"gst-certificate-{customerNumber.ToLowerInvariant()}.pdf",
                    ContentType = "application/pdf",
                    StoragePath = $"/documents/customers/{customerNumber}/gst-certificate-{customerNumber.ToLowerInvariant()}.pdf",
                    UploadedOn = Utc(2026, 7, 13, 10).AddMinutes(sequence % 1440)
                }
            ]
        };
    }

    private static string Pick(long sequence, params string[] values)
        => values[sequence % values.Length];

    private static DateTime Utc(int year, int month, int day, int hour = 0)
        => new(year, month, day, hour, 0, 0, DateTimeKind.Utc);
}
