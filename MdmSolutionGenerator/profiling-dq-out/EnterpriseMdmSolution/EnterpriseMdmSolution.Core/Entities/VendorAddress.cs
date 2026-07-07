namespace EnterpriseMdmSolution.Core.Entities;

public class VendorAddress : BaseEntity
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string AddressType { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public string? Region { get; set; }
    public bool IsDefault { get; set; }
    public Vendor? Vendor { get; set; }
    public Country? Country { get; set; }
}
