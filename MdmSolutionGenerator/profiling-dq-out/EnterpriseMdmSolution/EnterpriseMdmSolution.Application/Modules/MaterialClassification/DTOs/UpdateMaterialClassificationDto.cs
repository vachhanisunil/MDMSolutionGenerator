namespace EnterpriseMdmSolution.Application.Modules.MaterialClassification.DTOs;

public sealed class UpdateMaterialClassificationDto
{
    public int MaterialId { get; init; }
    public string ClassType { get; init; } = string.Empty;
    public string ClassValue { get; init; } = string.Empty;
    public string? CharacteristicName { get; init; }

    public int Id { get; init; }
}
