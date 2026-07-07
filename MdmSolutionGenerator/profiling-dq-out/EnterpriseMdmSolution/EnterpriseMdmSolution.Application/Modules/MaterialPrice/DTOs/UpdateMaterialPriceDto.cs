namespace EnterpriseMdmSolution.Application.Modules.MaterialPrice.DTOs;

public sealed class UpdateMaterialPriceDto
{
    public int MaterialId { get; init; }
    public int CurrencyId { get; init; }
    public string PriceType { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal PriceUnit { get; init; }
    public DateTime ValidFrom { get; init; }
    public DateTime? ValidTo { get; init; }
    public string? SourceSystem { get; init; }
}
