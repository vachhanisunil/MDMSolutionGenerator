using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialClassification : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    [Required]
    [MaxLength(50)]
    public string ClassType { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string ClassValue { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? CharacteristicName { get; set; }
    public Material? Material { get; set; }
}
