using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialBarcode : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    [Required]
    [MaxLength(30)]
    public string BarcodeType { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string BarcodeValue { get; set; } = string.Empty;
    public int? UnitOfMeasureId { get; set; }
    public bool IsPrimary { get; set; }
    public Material? Material { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
