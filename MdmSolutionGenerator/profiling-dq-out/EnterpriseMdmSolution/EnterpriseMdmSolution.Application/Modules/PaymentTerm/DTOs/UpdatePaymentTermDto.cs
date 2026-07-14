namespace EnterpriseMdmSolution.Application.Modules.PaymentTerm.DTOs;

public sealed class UpdatePaymentTermDto
{
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int NetDays { get; init; }

    public int Id { get; init; }
}
