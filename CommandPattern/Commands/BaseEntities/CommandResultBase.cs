namespace CommandPattern.Commands.BaseEntities;

public abstract class CommandResultBase
{
    public ICommandBase Command { get; }

    protected CommandResultBase(ICommandBase command)
    {
        Command = command;
    }
}