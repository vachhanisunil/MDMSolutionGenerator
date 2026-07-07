namespace EnterpriseMdmSolution.Core.Entities;

public class SalesOrganization : BaseEntity
{
    public int Id { get; set; }
    public string SalesOrganizationCode { get; set; } = string.Empty;
    public string SalesOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
    public ICollection<CustomerSalesArea> CustomerSalesAreas { get; set; } = [];
    public Currency? Currency { get; set; }
}
