namespace Calculator.Objects;

class AnalysisResult
{
    public List<string> Errors { get; } = new();

    public void Add(AnalysisResult result) => Errors.AddRange(result.Errors);

    public Status Status => Errors.Any() ? Status.Error : Status.Ok;
}

public enum Status
{
    Ok = 0,
    Error = 1
}