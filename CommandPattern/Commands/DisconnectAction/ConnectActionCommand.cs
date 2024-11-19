using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands.DisconnectAction;

public class ConnectActionCommand : ICommandBase<int, Result<int>>
{
    private bool _isValid;
    private Result<int> _result;
    private int Value { get; }

    public ConnectActionCommand(int value)
    {
        Value = value;
    }

    private void Validate()
    {
        _isValid = false;
    }

    public void Execute()
    {
        Validate();
        
        if (!_isValid)
        {
            _result = Result<int>.Failure("fail");
            return;
        }
        
        _result = Result<int>.Success(Value * 1000);
    }
    
    public Enum GetCurrentStep()
    {
        return TestBSteps.ConnectAction;
    }
    
    public int Get()
    {
        return Value;
    }
    
    public Result<int> GetResult()
    {
        return _result;
    }
}