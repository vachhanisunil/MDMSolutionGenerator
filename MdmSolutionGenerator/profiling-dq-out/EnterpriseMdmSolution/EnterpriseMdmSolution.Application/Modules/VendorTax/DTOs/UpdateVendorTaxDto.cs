namespace EnterpriseMdmSolution.Application.Modules.VendorTax.DTOs;

public sealed class UpdateVendorTaxDto
{
    public int VendorId { get; init; }
    public string TaxType { get; init; } = string.Empty;
    public string TaxNumber { get; init; } = string.Empty;
    public int CountryId { get; init; }
    public DateTime? ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public bool? IsTaxWithholdingApplicable { get; init; }

    public int Id { get; init; }
}
