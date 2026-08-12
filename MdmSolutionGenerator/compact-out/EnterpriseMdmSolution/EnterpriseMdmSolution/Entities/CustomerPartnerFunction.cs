using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerPartnerFunction : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(20)]
    public string PartnerFunctionCode { get; set; } = string.Empty;
    public int? PartnerCustomerId { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
    public Customer? Customer { get; set; }
}
