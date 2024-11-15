namespace CommandPattern.Commands.BaseEntities;

public interface ICommandResult<out TValue, out TResult>
{
    TValue Value { get; }
    TResult Result { get; }
}

public class CommandResult<TValue, TResult> : ICommandResult<TValue, TResult>
{
    public TValue Value { get; }
    public TResult Result { get; }

    public CommandResult(TValue value, TResult result)
    {
        Value = value;
        Result = result;
    }
}

