using Calculator.Interfaces;
using Calculator.Objects;

namespace Calculator.Analyzers;

class ArithmeticAnalyzer : IStringAnalyzer
{
    private readonly IEnumerable<IStringAnalyzer> _analyzers;

    public ArithmeticAnalyzer()
    {
        _analyzers = new List<IStringAnalyzer>
        {
            new BracketsAnalyzer()
        };
    }

    public AnalysisResult GetResult(string expression)
    {
        var result = new AnalysisResult();

        foreach (var analyzer in _analyzers)
        {
            var tempResult = analyzer.GetResult(expression);
            result.Add(tempResult);
        }

        return result;
    }
}