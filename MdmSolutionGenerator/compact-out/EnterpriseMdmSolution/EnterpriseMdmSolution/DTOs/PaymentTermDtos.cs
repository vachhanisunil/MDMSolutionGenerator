namespace EnterpriseMdmSolution.DTOs;

public sealed class PaymentTermDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NetDays { get; set; }
}

public sealed class CreatePaymentTermDto
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NetDays { get; set; }
}

public sealed class UpdatePaymentTermDto
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NetDays { get; set; }
}

public sealed class SearchPaymentTermDto : EnterpriseMdmSolution.Services.SearchRequest
{
}