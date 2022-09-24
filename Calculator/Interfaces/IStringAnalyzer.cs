using Calculator.Objects;

namespace Calculator.Interfaces;

public interface IStringAnalyzer
{
    public AnalysisResult Analyse(string expression);
}