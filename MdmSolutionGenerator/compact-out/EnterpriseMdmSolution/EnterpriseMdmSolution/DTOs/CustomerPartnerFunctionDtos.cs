namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerPartnerFunctionDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string PartnerFunctionCode { get; set; } = string.Empty;
    public int? PartnerCustomerId { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class CreateCustomerPartnerFunctionDto
{
    public int CustomerId { get; set; }
    public string PartnerFunctionCode { get; set; } = string.Empty;
    public int? PartnerCustomerId { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class UpdateCustomerPartnerFunctionDto
{
    public int CustomerId { get; set; }
    public string PartnerFunctionCode { get; set; } = string.Empty;
    public int? PartnerCustomerId { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
}

public sealed class SearchCustomerPartnerFunctionDto : EnterpriseMdmSolution.Services.SearchRequest
{
}