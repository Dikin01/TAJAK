namespace Calculator.Objects;

public class AnalysisResult
{
    private readonly List<string> _errors = new();
    
    public Status Status => Errors.Any() ? Status.Error : Status.Ok;

    public IReadOnlyCollection<string> Errors => _errors;
    
    public void AddError(string errorMessage) => _errors.Add(errorMessage);

    public void CopyErrors(AnalysisResult from) => _errors.AddRange(from.Errors);
}

public enum Status
{
    Ok = 0,
    Error = 1
}