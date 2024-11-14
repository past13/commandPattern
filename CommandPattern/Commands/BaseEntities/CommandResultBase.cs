namespace CommandPattern.Commands.BaseEntities;

public interface ICommandResult
{
    object Value { get; }
    object Result { get; }
}

public class CommandResult<TValue, TResult> : ICommandResult
{
    public TValue Value { get; }
    public TResult Result { get; }

    public CommandResult(TValue value, TResult result)
    {
        Value = value;
        Result = result;
    }

    object ICommandResult.Value => Value;
    object ICommandResult.Result => Result;
}

