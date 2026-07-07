namespace EnterpriseMdmSolution.Application.Modules.CustomerAddress.DTOs;

public sealed class CustomerAddressDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string AddressType { get; init; } = string.Empty;
    public string AddressLine1 { get; init; } = string.Empty;
    public string? AddressLine2 { get; init; }
    public string City { get; init; } = string.Empty;
    public string? State { get; init; }
    public string PostalCode { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public string? Region { get; init; }
    public decimal? Latitude { get; init; }
    public decimal? Longitude { get; init; }
    public bool IsDefault { get; init; }
}
