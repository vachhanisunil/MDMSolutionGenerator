namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

public sealed class MaterialBarcodeDto
{
    public int Id { get; init; }
    public int MaterialId { get; init; }
    public string BarcodeType { get; init; } = string.Empty;
    public string BarcodeValue { get; init; } = string.Empty;
    public int? UnitOfMeasureId { get; init; }
    public bool IsPrimary { get; init; }
}
