using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands.DisconnectAction;

public class ConnectActionCommand : ICommandBase 
{
    private bool _isValid;
    private Result<int> Result { get; set; }
    private int Value { get; set; }

    public ConnectActionCommand(int value)
    {
        Value = value;
    }

    private void Validate()
    {
        _isValid = true;
    }

    public bool GetState()
    {
        return true;
    }

    public void Execute()
    {
        Validate();
        
        if (!_isValid)
        {
            Result = Result<int>.Failure("fail");
            return;
        }
        
        Result = Result<int>.Success(Value * 1000);
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
        return Result;
    }
}