namespace EnterpriseMdmSolution.Application.Modules.Currency.DTOs;

public sealed class CurrencyDto
{
    public int Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public int DecimalPlaces { get; init; }
}
