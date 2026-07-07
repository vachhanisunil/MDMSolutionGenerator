namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerTax : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string TaxType { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsExempt { get; set; }
    public Customer? Customer { get; set; }
    public Country? Country { get; set; }
}
