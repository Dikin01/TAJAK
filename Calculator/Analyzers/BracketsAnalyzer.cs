using Calculator.Interfaces;
using Calculator.Objects;

namespace Calculator.Analyzers;

public class BracketsAnalyzer : IStringAnalyzer
{
    private const char Open = '(';
    private const char Close = ')';

    public AnalysisResult Analyse(string expression)
    {
        var bracketsStack = new Stack<char>();
        var result = new AnalysisResult();

        foreach (var symbol in expression)
        {
            if (symbol == Open)
            {
                bracketsStack.Push(symbol);
            }
            else if (symbol == Close)
            {
                var popSuccess = bracketsStack.TryPop(out var top);

                if (popSuccess) continue;

                result.AddError(Configuration.Errors["IncorrectBrackets"]);
                return result;
            }
        }

        if (bracketsStack.Count > 0)
            result.AddError(Configuration.Errors["UncloseBrackets"]);

        return result;
    }
}