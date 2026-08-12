using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class SalesOrganization : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string SalesOrganizationCode { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string SalesOrganizationName { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public ICollection<CustomerSalesArea> CustomerSalesAreas { get; set; } = [];
}
