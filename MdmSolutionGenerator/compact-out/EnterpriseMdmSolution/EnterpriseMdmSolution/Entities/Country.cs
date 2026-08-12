using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class Country : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(3)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Customer> Customers { get; set; } = [];
    public ICollection<CustomerAddress> CustomerAddresses { get; set; } = [];
    public ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = [];
    public ICollection<CustomerTax> CustomerTaxs { get; set; } = [];
    public ICollection<Vendor> Vendors { get; set; } = [];
    public ICollection<VendorAddress> VendorAddresses { get; set; } = [];
    public ICollection<VendorBankAccount> VendorBankAccounts { get; set; } = [];
    public ICollection<VendorTax> VendorTaxs { get; set; } = [];
    public ICollection<Plant> Plants { get; set; } = [];
}
