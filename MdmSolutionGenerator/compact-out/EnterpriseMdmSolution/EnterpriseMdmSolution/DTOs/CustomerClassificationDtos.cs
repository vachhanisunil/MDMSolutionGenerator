namespace EnterpriseMdmSolution.DTOs;

public sealed class CustomerClassificationDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string ClassificationType { get; set; } = string.Empty;
    public string ClassificationValue { get; set; } = string.Empty;
    public string? ClassificationGroup { get; set; }
}

public sealed class CreateCustomerClassificationDto
{
    public int CustomerId { get; set; }
    public string ClassificationType { get; set; } = string.Empty;
    public string ClassificationValue { get; set; } = string.Empty;
    public string? ClassificationGroup { get; set; }
}

public sealed class UpdateCustomerClassificationDto
{
    public int CustomerId { get; set; }
    public string ClassificationType { get; set; } = string.Empty;
    public string ClassificationValue { get; set; } = string.Empty;
    public string? ClassificationGroup { get; set; }
}

public sealed class SearchCustomerClassificationDto : EnterpriseMdmSolution.Services.SearchRequest
{
}