namespace Calculator.Objects;

public static class Configuration
{
    public static readonly IReadOnlyDictionary<string, string> Errors = new Dictionary<string, string>
    {
        { "IncorrectBrackets", "Closing brackets are incorrectly placed." },
        { "UncloseBrackets", "Not all brackets were closed." }
    };
}