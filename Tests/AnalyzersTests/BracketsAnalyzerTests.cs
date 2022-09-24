using Calculator.Analyzers;
using Calculator.Interfaces;
using Calculator.Objects;

namespace Tests.AnalyzersTests;

public class BracketsAnalyzerTests
{
    private readonly IStringAnalyzer _analyzer = new BracketsAnalyzer();

    [Fact]
    public void Analyze_ShouldReturn1Error_WhenExpressionContains1OpenBracket()
    {
        const string expression = "(";

        var result = _analyzer.Analyse(expression);

        result.Status.Should().Be(Status.Error);
        result.Errors.Should().Equal(Configuration.Errors["UncloseBrackets"]);
    }

    [Fact]
    public void Analyze_ShouldReturn1Error_WhenExpressionContains1CloseBracket()
    {
        const string expression = ")";

        var result = _analyzer.Analyse(expression);

        result.Status.Should().Be(Status.Error);
        result.Errors.Should().Equal(Configuration.Errors["IncorrectBrackets"]);
    }

    [Theory]
    [InlineData("()")]
    [InlineData("(a)")]
    [InlineData("a(a)")]
    [InlineData("a(a)a")]
    [InlineData("(a(a)a)")]
    [InlineData("((a)a)")]
    [InlineData("(a(a))")]
    [InlineData("((a)(a))")]
    public void Analyse_ShouldBeOk_WhenExpressionContainsCorrectOrderBrackets(string expression)
    {
        var result = _analyzer.Analyse(expression);

        result.Status.Should().Be(Status.Ok);
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Analyse_ShouldBeOk_WhenExpressionIsEmptyString()
    {
        var expression = string.Empty;

        var result = _analyzer.Analyse(expression);

        result.Status.Should().Be(Status.Ok);
        result.Errors.Should().BeEmpty();
    }
}