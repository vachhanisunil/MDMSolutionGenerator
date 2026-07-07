namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerPartnerFunction : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string PartnerFunctionCode { get; set; } = string.Empty;
    public int? PartnerCustomerId { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
    public Customer? Customer { get; set; }
}
