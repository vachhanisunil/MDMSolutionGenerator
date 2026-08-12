using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialPlant : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    [Required]
    [MaxLength(30)]
    public string ProcurementType { get; set; } = string.Empty;
    public decimal? ReorderPoint { get; set; }
    public decimal? MinimumLotSize { get; set; }
    public decimal? MaximumLotSize { get; set; }
    [MaxLength(20)]
    public string? MrpType { get; set; }
    public int? PlanningTimeFenceDays { get; set; }
    [MaxLength(50)]
    public string? ProfitCenter { get; set; }
    public Material? Material { get; set; }
    public Plant? Plant { get; set; }
}
