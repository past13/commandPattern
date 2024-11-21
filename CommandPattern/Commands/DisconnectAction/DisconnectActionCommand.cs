using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands.DisconnectAction;

public class DisconnectActionCommand : ICommandBase
{
    private bool _isValid { get; set; }
    private Result<int> Result { get; set; }
    private int Value { get; }
    
    public DisconnectActionCommand(int value)
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
        
        Result = Result<int>.Success(Value * 2000);
    }
    
    public Enum GetCurrentStep()
    {
        return TestBSteps.DisconnectAction;
    }
}