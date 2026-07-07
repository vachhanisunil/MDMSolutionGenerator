namespace EnterpriseMdmSolution.Core.Entities;

public class Currency : BaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DecimalPlaces { get; set; }
    public ICollection<Customer> Customers { get; set; } = [];
    public ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = [];
    public ICollection<MaterialPrice> MaterialPrices { get; set; } = [];
    public ICollection<Vendor> Vendors { get; set; } = [];
    public ICollection<VendorBankAccount> VendorBankAccounts { get; set; } = [];
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
    public ICollection<SalesOrganization> SalesOrganizations { get; set; } = [];
    public ICollection<PurchasingOrganization> PurchasingOrganizations { get; set; } = [];
}
