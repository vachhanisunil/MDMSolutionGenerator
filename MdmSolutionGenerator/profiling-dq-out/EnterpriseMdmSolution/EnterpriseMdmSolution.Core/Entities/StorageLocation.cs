namespace EnterpriseMdmSolution.Core.Entities;

public class StorageLocation : BaseEntity
{
    public int Id { get; set; }
    public string StorageLocationCode { get; set; } = string.Empty;
    public string StorageLocationName { get; set; } = string.Empty;
    public int PlantId { get; set; }
    public ICollection<MaterialStorage> MaterialStorages { get; set; } = [];
    public Plant? Plant { get; set; }
}
