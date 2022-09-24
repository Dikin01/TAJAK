using Calculator.Interfaces;
using Calculator.Objects;

namespace Calculator.Analyzers;

public class ArithmeticAnalyzer : IStringAnalyzer
{
    private readonly IEnumerable<IStringAnalyzer> _analyzers;

    public ArithmeticAnalyzer()
    {
        _analyzers = new List<IStringAnalyzer>
        {
            new BracketsAnalyzer()
        };
    }

    public AnalysisResult Analyse(string expression)
    {
        var result = new AnalysisResult();

        foreach (var analyzer in _analyzers)
        {
            var tempResult = analyzer.Analyse(expression);
            result.CopyErrors(tempResult);
        }

        return result;
    }
}