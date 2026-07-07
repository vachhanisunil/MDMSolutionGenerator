using System.Text;

namespace MdmSolutionGenerator.Generation;

internal static class Naming
{
    public static string Pascal(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "Item";
        }

        var builder = new StringBuilder();
        var capitalize = true;
        foreach (var ch in value)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                capitalize = true;
                continue;
            }

            builder.Append(capitalize ? char.ToUpperInvariant(ch) : ch);
            capitalize = false;
        }

        return builder.Length == 0 ? "Item" : builder.ToString();
    }

    public static string Camel(string value)
    {
        var pascal = Pascal(value);
        return char.ToLowerInvariant(pascal[0]) + pascal[1..];
    }

    public static string Plural(string value)
    {
        var word = Pascal(value);
        if (word.EndsWith("y", StringComparison.OrdinalIgnoreCase))
        {
            return word[..^1] + "ies";
        }

        if (word.EndsWith("s", StringComparison.OrdinalIgnoreCase))
        {
            return word + "es";
        }

        return word + "s";
    }

    public static string NamespacePart(string value) => Pascal(value).Replace(" ", "", StringComparison.Ordinal);
}
