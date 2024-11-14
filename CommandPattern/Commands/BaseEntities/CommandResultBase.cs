namespace CommandPattern.Commands.BaseEntities;

public abstract class CommandResultBase
{
    public HrisSteps Step { get; }

    protected CommandResultBase(HrisSteps step)
    {
        Step = step;
    }
}

public class CommandResult<TResult> : CommandResultBase
{
    public TResult Result { get; }

    public CommandResult(HrisSteps step, TResult result) : base(step)
    {
        Result = result;
    }
}