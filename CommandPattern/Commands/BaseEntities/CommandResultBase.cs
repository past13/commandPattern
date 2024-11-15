namespace CommandPattern.Commands.BaseEntities;

public class CommandResult<TValue, TResult>
{
    public TValue Value { get; }
    public TResult Result { get; }

    public CommandResult(TValue value, TResult result)
    {
        Value = value;
        Result = result;
    }
}

