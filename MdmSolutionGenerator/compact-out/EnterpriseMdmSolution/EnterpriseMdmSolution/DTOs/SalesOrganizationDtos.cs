namespace EnterpriseMdmSolution.DTOs;

public sealed class SalesOrganizationDto
{
    public int Id { get; set; }
    public string SalesOrganizationCode { get; set; } = string.Empty;
    public string SalesOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class CreateSalesOrganizationDto
{
    public string SalesOrganizationCode { get; set; } = string.Empty;
    public string SalesOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class UpdateSalesOrganizationDto
{
    public string SalesOrganizationCode { get; set; } = string.Empty;
    public string SalesOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class SearchSalesOrganizationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}