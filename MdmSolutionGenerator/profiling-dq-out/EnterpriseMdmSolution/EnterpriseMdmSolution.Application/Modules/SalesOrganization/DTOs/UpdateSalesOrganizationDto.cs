namespace EnterpriseMdmSolution.Application.Modules.SalesOrganization.DTOs;

public sealed class UpdateSalesOrganizationDto
{
    public string SalesOrganizationCode { get; init; } = string.Empty;
    public string SalesOrganizationName { get; init; } = string.Empty;
    public int CurrencyId { get; init; }
}
