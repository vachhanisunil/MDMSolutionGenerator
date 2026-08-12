namespace EnterpriseMdmSolution.DTOs;

public sealed class CurrencyDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DecimalPlaces { get; set; }
}

public sealed class CreateCurrencyDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DecimalPlaces { get; set; }
}

public sealed class UpdateCurrencyDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DecimalPlaces { get; set; }
}

public sealed class SearchCurrencyDto : EnterpriseMdmSolution.Services.SearchRequest
{
}