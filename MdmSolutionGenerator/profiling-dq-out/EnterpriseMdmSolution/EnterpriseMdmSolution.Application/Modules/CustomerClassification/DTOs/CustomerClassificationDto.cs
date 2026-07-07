namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;

public sealed class CustomerClassificationDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string ClassificationType { get; init; } = string.Empty;
    public string ClassificationValue { get; init; } = string.Empty;
    public string? ClassificationGroup { get; init; }
}
