﻿using CommandPattern.Commands.BaseEntities;

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

    private void Validate()
    {
        _isValid = true;
    }

    public void Execute()
    {
        Validate();
        
        if (!_isValid)
        {
            _result = Result<int>.Failure("fail");
            return;
        }
        
        _result = Result<int>.Success(Value * 2000);
    }
    
    public Enum GetCurrentStep()
    {
        return TestBSteps.DisconnectAction;
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