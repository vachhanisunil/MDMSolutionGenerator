namespace EnterpriseMdmSolution.Core.Entities;

public class PurchasingOrganization : BaseEntity
{
    public int Id { get; set; }
    public string PurchasingOrganizationCode { get; set; } = string.Empty;
    public string PurchasingOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
    public ICollection<VendorPurchasingOrganization> VendorPurchasingOrganizations { get; set; } = [];
    public Currency? Currency { get; set; }
}
