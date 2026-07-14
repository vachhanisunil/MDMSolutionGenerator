namespace EnterpriseMdmSolution.Application.Modules.MaterialGroup.DTOs;

public sealed class UpdateMaterialGroupDto
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;

    public int Id { get; init; }
}
