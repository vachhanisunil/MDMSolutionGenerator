namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialClassification : BaseEntity
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string ClassType { get; set; } = string.Empty;
    public string ClassValue { get; set; } = string.Empty;
    public string? CharacteristicName { get; set; }
    public Material? Material { get; set; }
}
