namespace EnterpriseMdmSolution.DTOs;

public sealed class VendorTaxDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? IsTaxWithholdingApplicable { get; set; }
}

public sealed class CreateVendorTaxDto
{
    public int VendorId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? IsTaxWithholdingApplicable { get; set; }
}

public sealed class UpdateVendorTaxDto
{
    public int VendorId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? IsTaxWithholdingApplicable { get; set; }
}

public sealed class SearchVendorTaxDto : EnterpriseMdmSolution.Services.SearchRequest
{
}