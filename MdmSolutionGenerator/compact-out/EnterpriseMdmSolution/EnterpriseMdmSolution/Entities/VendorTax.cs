using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorTax : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    [Required]
    [MaxLength(50)]
    public string TaxType { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string TaxNumber { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? IsTaxWithholdingApplicable { get; set; }
    public Vendor? Vendor { get; set; }
    public Country? Country { get; set; }
}
