namespace EnterpriseMdmSolution.Application.Modules.MaterialForecast.DTOs;

public sealed class UpdateMaterialForecastDto
{
    public int MaterialId { get; init; }
    public int PlantId { get; init; }
    public string ForecastPeriod { get; init; } = string.Empty;
    public decimal ForecastQuantity { get; init; }
    public int ForecastUnitOfMeasureId { get; init; }
    public decimal? ConfidencePercent { get; init; }

    public int Id { get; init; }
}
