namespace EnterpriseMdmSolution.Application.Modules.CustomerPartnerFunction.DTOs;

public sealed class CreateCustomerPartnerFunctionDto
{
    public int CustomerId { get; init; }
    public string PartnerFunctionCode { get; init; } = string.Empty;
    public int? PartnerCustomerId { get; init; }
    public string? Description { get; init; }
    public bool IsDefault { get; init; }
}
