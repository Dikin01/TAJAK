using Calculator.Objects;

namespace Calculator.Interfaces;

interface IStringAnalyzer
{
    public AnalysisResult GetResult(string expression);
}