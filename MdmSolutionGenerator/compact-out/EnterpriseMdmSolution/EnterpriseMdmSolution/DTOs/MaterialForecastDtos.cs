namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialForecastDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ForecastPeriod { get; set; } = string.Empty;
    public decimal ForecastQuantity { get; set; }
    public int ForecastUnitOfMeasureId { get; set; }
    public decimal? ConfidencePercent { get; set; }
}

public sealed class CreateMaterialForecastDto
{
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ForecastPeriod { get; set; } = string.Empty;
    public decimal ForecastQuantity { get; set; }
    public int ForecastUnitOfMeasureId { get; set; }
    public decimal? ConfidencePercent { get; set; }
}

public sealed class UpdateMaterialForecastDto
{
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ForecastPeriod { get; set; } = string.Empty;
    public decimal ForecastQuantity { get; set; }
    public int ForecastUnitOfMeasureId { get; set; }
    public decimal? ConfidencePercent { get; set; }
}

public sealed class SearchMaterialForecastDto : EnterpriseMdmSolution.Services.SearchRequest
{
}