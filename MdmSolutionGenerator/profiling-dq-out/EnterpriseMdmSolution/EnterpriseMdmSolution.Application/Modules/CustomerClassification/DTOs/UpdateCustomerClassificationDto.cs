namespace EnterpriseMdmSolution.Application.Modules.CustomerClassification.DTOs;

public sealed class UpdateCustomerClassificationDto
{
    public int CustomerId { get; init; }
    public string ClassificationType { get; init; } = string.Empty;
    public string ClassificationValue { get; init; } = string.Empty;
    public string? ClassificationGroup { get; init; }
}
