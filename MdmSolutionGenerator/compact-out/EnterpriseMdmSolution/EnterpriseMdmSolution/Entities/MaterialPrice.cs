using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialPrice : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int CurrencyId { get; set; }
    [Required]
    [MaxLength(30)]
    public string PriceType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal PriceUnit { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    [MaxLength(50)]
    public string? SourceSystem { get; set; }
    public Material? Material { get; set; }
    public Currency? Currency { get; set; }
}
