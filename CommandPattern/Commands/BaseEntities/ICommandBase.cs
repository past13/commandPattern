namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase<out TValue, out TResult> : ICommandBase
{
    TValue Get();
    TResult GetResult();
}

public interface ICommandBase
{
    void Validate();
    void Execute();
    HrisSteps GetCurrentStep();
}
