namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialBarcode : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string BarcodeType { get; set; } = string.Empty;
    public string BarcodeValue { get; set; } = string.Empty;
    public int? UnitOfMeasureId { get; set; }
    public bool IsPrimary { get; set; }
    public Material? Material { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }
}
