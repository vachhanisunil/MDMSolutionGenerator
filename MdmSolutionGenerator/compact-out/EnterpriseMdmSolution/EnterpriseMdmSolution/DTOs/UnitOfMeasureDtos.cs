namespace EnterpriseMdmSolution.DTOs;

public sealed class UnitOfMeasureDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Dimension { get; set; }
}

public sealed class CreateUnitOfMeasureDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Dimension { get; set; }
}

public sealed class UpdateUnitOfMeasureDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Dimension { get; set; }
}

public sealed class SearchUnitOfMeasureDto : EnterpriseMdmSolution.Services.SearchRequest
{
}