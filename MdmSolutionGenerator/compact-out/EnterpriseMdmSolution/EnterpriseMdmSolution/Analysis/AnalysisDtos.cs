namespace EnterpriseMdmSolution.Analysis;

public sealed class BusinessObjectRunDto
{
    public Guid RunId { get; set; }
    public string BusinessObjectName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset StartedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}