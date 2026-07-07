namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

public sealed class UnitOfMeasureDto
{
    public int Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? Dimension { get; init; }
}
