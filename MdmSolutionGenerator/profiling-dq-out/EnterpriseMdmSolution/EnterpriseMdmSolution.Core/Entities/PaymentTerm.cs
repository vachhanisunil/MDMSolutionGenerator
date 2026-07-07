namespace EnterpriseMdmSolution.Core.Entities;

public class PaymentTerm : BaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NetDays { get; set; }
    public ICollection<CustomerSalesArea> CustomerSalesAreas { get; set; } = [];
    public ICollection<Vendor> Vendors { get; set; } = [];
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
}
