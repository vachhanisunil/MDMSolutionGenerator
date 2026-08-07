namespace CustomerNdjsonGenerator.Api.Models;

public sealed class CustomerNdjsonGenerationRequest
{
    public long RecordCount { get; init; } = 1_000_000;
    public long StartCustomerSequence { get; init; } = 10001;
    public string? FileName { get; init; }
    public int CountryId { get; init; } = 1;
    public int CurrencyId { get; init; } = 1;
    public int SalesOrganizationId { get; init; } = 1;
    public int PaymentTermId { get; init; } = 1;
}
