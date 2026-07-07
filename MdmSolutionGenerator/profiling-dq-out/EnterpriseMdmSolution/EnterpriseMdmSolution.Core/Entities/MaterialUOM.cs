namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialUOM : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal ConversionNumerator { get; set; }
    public decimal ConversionDenominator { get; set; }
    public string? Barcode { get; set; }
    public bool IsBaseUnit { get; set; }
    public Material? Material { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
