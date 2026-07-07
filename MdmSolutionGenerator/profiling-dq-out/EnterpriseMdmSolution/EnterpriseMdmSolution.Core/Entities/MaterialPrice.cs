namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialPrice : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int CurrencyId { get; set; }
    public string PriceType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal PriceUnit { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? SourceSystem { get; set; }
    public Material? Material { get; set; }
    public Currency? Currency { get; set; }
}
