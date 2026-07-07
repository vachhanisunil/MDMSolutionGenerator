namespace EnterpriseMdmSolution.Core.Entities;

public class VendorTax : BaseEntity
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? IsTaxWithholdingApplicable { get; set; }
    public Vendor? Vendor { get; set; }
    public Country? Country { get; set; }
}
