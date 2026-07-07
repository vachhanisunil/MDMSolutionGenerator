namespace EnterpriseMdmSolution.Application.Modules.UnitOfMeasure.DTOs;

public sealed class UpdateUnitOfMeasureDto
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? Dimension { get; init; }
}
