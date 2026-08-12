namespace EnterpriseMdmSolution.DTOs;

public sealed class MaterialGroupDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public sealed class CreateMaterialGroupDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public sealed class UpdateMaterialGroupDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public sealed class SearchMaterialGroupDto : EnterpriseMdmSolution.Services.SearchRequest
{
}