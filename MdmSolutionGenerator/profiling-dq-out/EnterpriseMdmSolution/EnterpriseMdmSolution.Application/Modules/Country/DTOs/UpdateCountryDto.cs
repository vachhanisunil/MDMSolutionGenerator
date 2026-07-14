namespace EnterpriseMdmSolution.Application.Modules.Country.DTOs;

public sealed class UpdateCountryDto
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;

    public int Id { get; init; }
}
