namespace EnterpriseMdmSolution.Core.Entities;

public class Country : BaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
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
