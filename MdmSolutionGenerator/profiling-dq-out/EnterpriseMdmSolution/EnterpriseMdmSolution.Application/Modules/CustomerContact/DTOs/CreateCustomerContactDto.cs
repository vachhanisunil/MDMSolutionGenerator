namespace EnterpriseMdmSolution.Application.Modules.CustomerContact.DTOs;

public sealed class CreateCustomerContactDto
{
    public int CustomerId { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? Email { get; init; }
    public string? Phone { get; init; }
    public string? MobilePhone { get; init; }
    public string? Designation { get; init; }
    public string? Department { get; init; }
    public string? PreferredLanguage { get; init; }
    public bool IsPrimary { get; init; }
}
