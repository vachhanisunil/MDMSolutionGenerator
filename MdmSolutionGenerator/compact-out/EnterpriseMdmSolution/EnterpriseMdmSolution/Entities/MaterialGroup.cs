using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialGroup : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Material> Materials { get; set; } = [];
}
