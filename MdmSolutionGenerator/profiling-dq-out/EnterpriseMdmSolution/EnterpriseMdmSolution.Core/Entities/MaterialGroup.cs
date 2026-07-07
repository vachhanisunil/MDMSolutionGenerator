namespace EnterpriseMdmSolution.Core.Entities;

public class MaterialGroup : BaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ICollection<Material> Materials { get; set; } = [];
}
