namespace EnterpriseMdmSolution.Application.Modules.MaterialUOM.DTOs;

public sealed class UpdateMaterialUOMDto
{
    public int MaterialId { get; init; }
    public int UnitOfMeasureId { get; init; }
    public decimal ConversionNumerator { get; init; }
    public decimal ConversionDenominator { get; init; }
    public string? Barcode { get; init; }
    public bool IsBaseUnit { get; init; }
}
