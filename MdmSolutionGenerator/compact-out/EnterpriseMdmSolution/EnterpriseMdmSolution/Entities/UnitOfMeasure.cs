using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class UnitOfMeasure : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Dimension { get; set; }
    public ICollection<Material> Materials { get; set; } = [];
    public ICollection<MaterialVendor> MaterialVendors { get; set; } = [];
    public ICollection<MaterialUOM> MaterialUOMs { get; set; } = [];
    public ICollection<MaterialForecast> MaterialForecasts { get; set; } = [];
    public ICollection<MaterialBarcode> MaterialBarcodes { get; set; } = [];
}
