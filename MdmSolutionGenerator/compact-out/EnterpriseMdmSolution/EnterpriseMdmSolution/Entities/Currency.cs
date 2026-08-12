using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class Currency : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(3)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
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
