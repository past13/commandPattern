using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands;

// [CommandStep(typeof(TestBSteps), (int)TestBSteps.RemoveReport)]
public class RemoveReportCommand : ICommandBase
{
    private static TestBSteps Step => TestBSteps.RemoveReport;
    
    private bool _isValid;
    private Result<string> _result;
    private string Value { get; }

    public RemoveReportCommand(string value)
    {
        Value = value;
    }

    private void Validate()
    {
        _isValid = true;
    }

    public bool GetState()
    {
        return false;
    }

    public void Execute()
    {
        Validate();
        
        if (!_isValid)
        {
            _result = Result<string>.Failure("fail");
            return;
        }
        
        _result = Result<string>.Success("AA");
    }

    public Enum GetCurrentStep() => Step;

    public string Get() => Value;
}