namespace EnterpriseMdmSolution.Application.Modules.MaterialPlant.DTOs;

public sealed class UpdateMaterialPlantDto
{
    public int MaterialId { get; init; }
    public int PlantId { get; init; }
    public string ProcurementType { get; init; } = string.Empty;
    public decimal? ReorderPoint { get; init; }
    public decimal? MinimumLotSize { get; init; }
    public decimal? MaximumLotSize { get; init; }
    public string? MrpType { get; init; }
    public int? PlanningTimeFenceDays { get; init; }
    public string? ProfitCenter { get; init; }

    public int Id { get; init; }
}
