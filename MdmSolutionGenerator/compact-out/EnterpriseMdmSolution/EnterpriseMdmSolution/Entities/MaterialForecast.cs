using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class MaterialForecast : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    [Required]
    [MaxLength(20)]
    public string ForecastPeriod { get; set; } = string.Empty;
    public decimal ForecastQuantity { get; set; }
    public int ForecastUnitOfMeasureId { get; set; }
    public decimal? ConfidencePercent { get; set; }
    public Material? Material { get; set; }
    public Plant? Plant { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
