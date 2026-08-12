namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorContactDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MobilePhone { get; set; }
    public string? Designation { get; set; }
    public string? Department { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class CreateVendorContactDto
{
    public int VendorId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MobilePhone { get; set; }
    public string? Designation { get; set; }
    public string? Department { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class UpdateVendorContactDto
{
    public int VendorId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MobilePhone { get; set; }
    public string? Designation { get; set; }
    public string? Department { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class SearchVendorContactDto : EnterpriseMdmSolution.Services.SearchRequest
{
}