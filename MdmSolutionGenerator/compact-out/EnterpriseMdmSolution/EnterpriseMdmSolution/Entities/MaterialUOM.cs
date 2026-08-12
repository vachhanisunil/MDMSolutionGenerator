using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialUOM : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int UnitOfMeasureId { get; set; }
    public decimal ConversionNumerator { get; set; }
    public decimal ConversionDenominator { get; set; }
    [MaxLength(50)]
    public string? Barcode { get; set; }
    public bool IsBaseUnit { get; set; }
    public Material? Material { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
