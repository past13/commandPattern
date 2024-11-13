namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase
{
    int Id { get; }
    void Execute();
    void Undo();
}

public interface ICommandBase<TResult> : ICommandBase
{
    TResult GetResult();
}