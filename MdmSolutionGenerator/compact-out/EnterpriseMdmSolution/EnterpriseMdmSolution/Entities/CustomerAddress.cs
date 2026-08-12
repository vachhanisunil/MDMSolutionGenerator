using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerAddress : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(30)]
    public string AddressType { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string AddressLine1 { get; set; } = string.Empty;
    [MaxLength(200)]
    public string? AddressLine2 { get; set; }
    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? State { get; set; }
    [Required]
    [MaxLength(20)]
    public string PostalCode { get; set; } = string.Empty;
    public int CountryId { get; set; }
    [MaxLength(100)]
    public string? Region { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool IsDefault { get; set; }
    public Customer? Customer { get; set; }
    public Country? Country { get; set; }
}
