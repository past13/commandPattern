using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands.DisconnectAction;

public class DisconnectActionCommand : ICommandBase<int, Result<int>>
{
    private bool _isValid;
    private Result<int> _result;
    private int Value { get; }

    public DisconnectActionCommand(int value)
    {
        Value = value;
    }

    public void Validate()
    {
        _isValid = true;
    }

    public void Execute()
    {
        if (!_isValid)
        {
            _result = Result<int>.Failure("fail");
            return;
        }
        
        _result = Result<int>.Success(Value);
    }
    
    public int Get()
    {
        return Value * 1000;
    }
    
    public HrisSteps GetCurrentStep()
    {
        return HrisSteps.DisconnectAction;
    }
    
    public Result<int> GetResult()
    {
        return _result;
    }
}