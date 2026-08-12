using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class StorageLocation : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string StorageLocationCode { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string StorageLocationName { get; set; } = string.Empty;
    public int PlantId { get; set; }
    public Plant? Plant { get; set; }
    public ICollection<MaterialStorage> MaterialStorages { get; set; } = [];
}
