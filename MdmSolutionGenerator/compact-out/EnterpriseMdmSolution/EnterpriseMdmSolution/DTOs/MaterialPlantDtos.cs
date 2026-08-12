namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialPlantDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ProcurementType { get; set; } = string.Empty;
    public decimal? ReorderPoint { get; set; }
    public decimal? MinimumLotSize { get; set; }
    public decimal? MaximumLotSize { get; set; }
    public string? MrpType { get; set; }
    public int? PlanningTimeFenceDays { get; set; }
    public string? ProfitCenter { get; set; }
}

public sealed class CreateMaterialPlantDto
{
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ProcurementType { get; set; } = string.Empty;
    public decimal? ReorderPoint { get; set; }
    public decimal? MinimumLotSize { get; set; }
    public decimal? MaximumLotSize { get; set; }
    public string? MrpType { get; set; }
    public int? PlanningTimeFenceDays { get; set; }
    public string? ProfitCenter { get; set; }
}

public sealed class UpdateMaterialPlantDto
{
    public int MaterialId { get; set; }
    public int PlantId { get; set; }
    public string ProcurementType { get; set; } = string.Empty;
    public decimal? ReorderPoint { get; set; }
    public decimal? MinimumLotSize { get; set; }
    public decimal? MaximumLotSize { get; set; }
    public string? MrpType { get; set; }
    public int? PlanningTimeFenceDays { get; set; }
    public string? ProfitCenter { get; set; }
}

public sealed class SearchMaterialPlantDto : EnterpriseMdmSolution.Services.SearchRequest
{
}