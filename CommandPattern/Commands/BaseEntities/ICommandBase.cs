namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase<TResult> : ICommandBase
{
    TResult GetResult();
}

public interface ICommandBase
{
    void Execute();
    HrisSteps GetCurrentStep();
}
