namespace EnterpriseMdmSolution.Application.Modules.PurchasingOrganization.DTOs;

public sealed class UpdatePurchasingOrganizationDto
{
    public string PurchasingOrganizationCode { get; init; } = string.Empty;
    public string PurchasingOrganizationName { get; init; } = string.Empty;
    public int CurrencyId { get; init; }
}
