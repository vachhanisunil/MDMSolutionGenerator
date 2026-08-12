namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorAddressDto
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
}

public sealed class CreateVendorAddressDto
{
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
}

public sealed class UpdateVendorAddressDto
{
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
}

public sealed class SearchVendorAddressDto : EnterpriseMdmSolution.Services.SearchRequest
{
}