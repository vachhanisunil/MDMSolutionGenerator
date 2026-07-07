namespace EnterpriseMdmSolution.Core.Entities;

public class CustomerContact : BaseEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? MobilePhone { get; set; }
    public string? Designation { get; set; }
    public string? Department { get; set; }
    public string? PreferredLanguage { get; set; }
    public bool IsPrimary { get; set; }
    public Customer? Customer { get; set; }
}
