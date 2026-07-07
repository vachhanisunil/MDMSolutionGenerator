namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerAddress : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string AddressType { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public string? Region { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool IsDefault { get; set; }
    public Customer? Customer { get; set; }
    public Country? Country { get; set; }
}
