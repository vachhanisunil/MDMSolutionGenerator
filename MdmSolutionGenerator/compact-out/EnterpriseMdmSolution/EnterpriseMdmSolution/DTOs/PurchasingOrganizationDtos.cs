namespace EnterpriseMdmSolution.DTOs;

public sealed class PurchasingOrganizationDto
{
    public int Id { get; set; }
    public string PurchasingOrganizationCode { get; set; } = string.Empty;
    public string PurchasingOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class CreatePurchasingOrganizationDto
{
    public string PurchasingOrganizationCode { get; set; } = string.Empty;
    public string PurchasingOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class UpdatePurchasingOrganizationDto
{
    public string PurchasingOrganizationCode { get; set; } = string.Empty;
    public string PurchasingOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
}

public sealed class SearchPurchasingOrganizationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}