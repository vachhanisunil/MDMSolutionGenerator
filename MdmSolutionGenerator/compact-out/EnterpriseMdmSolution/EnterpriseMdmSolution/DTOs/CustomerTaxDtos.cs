namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerTaxDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsExempt { get; set; }
}

public sealed class CreateCustomerTaxDto
{
    public int CustomerId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsExempt { get; set; }
}

public sealed class UpdateCustomerTaxDto
{
    public int CustomerId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsExempt { get; set; }
}

public sealed class SearchCustomerTaxDto : EnterpriseMdmSolution.Services.SearchRequest
{
}