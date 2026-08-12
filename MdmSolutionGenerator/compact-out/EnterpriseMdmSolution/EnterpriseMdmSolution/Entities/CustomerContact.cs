using System.ComponentModel.DataAnnotations;

namespace EnterpriseMdmSolution.Entities;

public sealed class CustomerContact : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(250)]
    public string? Email { get; set; }
    [MaxLength(30)]
    public string? Phone { get; set; }
    [MaxLength(30)]
    public string? MobilePhone { get; set; }
    [MaxLength(100)]
    public string? Designation { get; set; }
    [MaxLength(100)]
    public string? Department { get; set; }
    [MaxLength(20)]
    public string? PreferredLanguage { get; set; }
    public bool IsPrimary { get; set; }
    public Customer? Customer { get; set; }
}
