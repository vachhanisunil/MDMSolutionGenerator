namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialDto
{
    public int Id { get; set; }
    public string MaterialNumber { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string MaterialType { get; set; } = string.Empty;
    public int MaterialGroupId { get; set; }
    public int BaseUnitOfMeasureId { get; set; }
    public string? GlobalTradeItemNumber { get; set; }
    public string? ProductHierarchy { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? NetWeight { get; set; }
    public int? WeightUnitOfMeasureId { get; set; }
    public bool IsBatchManaged { get; set; }
    public bool IsSerialManaged { get; set; }
    public bool IsActive { get; set; }
}

public sealed class CreateMaterialDto
{
    public string MaterialNumber { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string MaterialType { get; set; } = string.Empty;
    public int MaterialGroupId { get; set; }
    public int BaseUnitOfMeasureId { get; set; }
    public string? GlobalTradeItemNumber { get; set; }
    public string? ProductHierarchy { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? NetWeight { get; set; }
    public int? WeightUnitOfMeasureId { get; set; }
    public bool IsBatchManaged { get; set; }
    public bool IsSerialManaged { get; set; }
    public bool IsActive { get; set; }
}

public sealed class UpdateMaterialDto
{
    public string MaterialNumber { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string MaterialType { get; set; } = string.Empty;
    public int MaterialGroupId { get; set; }
    public int BaseUnitOfMeasureId { get; set; }
    public string? GlobalTradeItemNumber { get; set; }
    public string? ProductHierarchy { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? NetWeight { get; set; }
    public int? WeightUnitOfMeasureId { get; set; }
    public bool IsBatchManaged { get; set; }
    public bool IsSerialManaged { get; set; }
    public bool IsActive { get; set; }
}

public sealed class SearchMaterialDto : EnterpriseMdmSolution.Services.SearchRequest
{
}