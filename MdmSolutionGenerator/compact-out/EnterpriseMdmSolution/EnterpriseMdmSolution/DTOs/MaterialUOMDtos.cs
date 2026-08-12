namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialUOMDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal ConversionNumerator { get; set; }
    public decimal ConversionDenominator { get; set; }
    public string? Barcode { get; set; }
    public bool IsBaseUnit { get; set; }
}

public sealed class CreateMaterialUOMDto
{
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal ConversionNumerator { get; set; }
    public decimal ConversionDenominator { get; set; }
    public string? Barcode { get; set; }
    public bool IsBaseUnit { get; set; }
}

public sealed class UpdateMaterialUOMDto
{
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal ConversionNumerator { get; set; }
    public decimal ConversionDenominator { get; set; }
    public string? Barcode { get; set; }
    public bool IsBaseUnit { get; set; }
}

public sealed class SearchMaterialUOMDto : EnterpriseMdmSolution.Services.SearchRequest
{
}