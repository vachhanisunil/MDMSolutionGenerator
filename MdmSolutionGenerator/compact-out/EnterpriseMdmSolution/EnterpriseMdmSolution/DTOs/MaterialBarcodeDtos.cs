namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialBarcodeDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string BarcodeType { get; set; } = string.Empty;
    public string BarcodeValue { get; set; } = string.Empty;
    public int? UnitOfMeasureId { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class CreateMaterialBarcodeDto
{
    public int MaterialId { get; set; }
    public string BarcodeType { get; set; } = string.Empty;
    public string BarcodeValue { get; set; } = string.Empty;
    public int? UnitOfMeasureId { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class UpdateMaterialBarcodeDto
{
    public int MaterialId { get; set; }
    public string BarcodeType { get; set; } = string.Empty;
    public string BarcodeValue { get; set; } = string.Empty;
    public int? UnitOfMeasureId { get; set; }
    public bool IsPrimary { get; set; }
}

public sealed class SearchMaterialBarcodeDto : EnterpriseMdmSolution.Services.SearchRequest
{
}