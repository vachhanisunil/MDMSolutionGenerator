namespace EnterpriseMdmSolution.Application.Modules.CustomerTax.DTOs;

public sealed class UpdateCustomerTaxDto
{
    public int CustomerId { get; init; }
    public string TaxType { get; init; } = string.Empty;
    public string TaxNumber { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public DateTime? ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public bool IsExempt { get; init; }

    public int Id { get; init; }
}
