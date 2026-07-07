namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialForecast : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ForecastPeriod { get; set; } = string.Empty;
    public decimal ForecastQuantity { get; set; }
    public int ForecastUnitOfMeasureId { get; set; }
    public decimal? ConfidencePercent { get; set; }
    public Material? Material { get; set; }
    public Plant? Plant { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
