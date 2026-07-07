namespace EnterpriseMdmSolution.Core.Common;

public class SearchRequest
{
    public List<SearchFilter> Filters { get; init; } = [];
    public string? SortBy { get; init; }
    public bool SortDescending { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}

public sealed class SearchFilter
{
    public string Field { get; init; } = "";
    public string Operator { get; init; } = "equals";
    public string? Value { get; init; }
}