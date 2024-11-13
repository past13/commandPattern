namespace CommandPattern.Commands.BaseEntities;

public class CommandResult<TResult> : CommandResultBase
{
    public TResult Result { get; }

    public CommandResult(ICommandBase command, TResult result) : base(command)
    {
        Result = result;
    }
}