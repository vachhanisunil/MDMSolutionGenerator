namespace EnterpriseMdmSolution.Application.Modules.VendorAddress.DTOs;

public sealed class CreateVendorAddressDto
{
    public int VendorId { get; init; }
    public string AddressType { get; init; } = string.Empty;
    public string AddressLine1 { get; init; } = string.Empty;
    public string? AddressLine2 { get; init; }
    public string City { get; init; } = string.Empty;
    public string? State { get; init; }
    public string PostalCode { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public string? Region { get; init; }
    public bool IsDefault { get; init; }
}
