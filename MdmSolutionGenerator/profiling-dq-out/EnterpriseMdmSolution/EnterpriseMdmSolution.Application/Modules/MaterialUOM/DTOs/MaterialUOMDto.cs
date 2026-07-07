namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

public sealed class MaterialUOMDto
{
    public int Id { get; init; }
    public int MaterialId { get; init; }
    public int UnitOfMeasureId { get; init; }
    public decimal ConversionNumerator { get; init; }
    public decimal ConversionDenominator { get; init; }
    public string? Barcode { get; init; }
    public bool IsBaseUnit { get; init; }
}
