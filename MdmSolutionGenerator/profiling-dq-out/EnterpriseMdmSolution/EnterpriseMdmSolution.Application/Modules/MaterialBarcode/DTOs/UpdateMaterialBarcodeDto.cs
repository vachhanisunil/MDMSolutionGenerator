namespace EnterpriseMdmSolution.Application.Modules.MaterialBarcode.DTOs;

public sealed class UpdateMaterialBarcodeDto
{
    public int MaterialId { get; init; }
    public string BarcodeType { get; init; } = string.Empty;
    public string BarcodeValue { get; init; } = string.Empty;
    public int? UnitOfMeasureId { get; init; }
    public bool IsPrimary { get; init; }
}
