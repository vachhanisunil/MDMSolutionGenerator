using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class VendorBankAccount : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int VendorId { get; set; }
    [Required]
    [MaxLength(150)]
    public string BankName { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string AccountNumber { get; set; } = string.Empty;
    [MaxLength(20)]
    public string? IfscCode { get; set; }
    [MaxLength(20)]
    public string? SwiftCode { get; set; }
    public int CurrencyId { get; set; }
    [MaxLength(150)]
    public string? AccountHolderName { get; set; }
    public int? BankCountryId { get; set; }
    public bool IsDefault { get; set; }
    public Vendor? Vendor { get; set; }
    public Currency? Currency { get; set; }
    public Country? Country { get; set; }
}
