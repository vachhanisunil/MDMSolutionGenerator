namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialClassificationDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public string ClassType { get; set; } = string.Empty;
    public string ClassValue { get; set; } = string.Empty;
    public string? CharacteristicName { get; set; }
}

public sealed class CreateMaterialClassificationDto
{
    public int MaterialId { get; set; }
    public string ClassType { get; set; } = string.Empty;
    public string ClassValue { get; set; } = string.Empty;
    public string? CharacteristicName { get; set; }
}

public sealed class UpdateMaterialClassificationDto
{
    public int MaterialId { get; set; }
    public string ClassType { get; set; } = string.Empty;
    public string ClassValue { get; set; } = string.Empty;
    public string? CharacteristicName { get; set; }
}

public sealed class SearchMaterialClassificationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}