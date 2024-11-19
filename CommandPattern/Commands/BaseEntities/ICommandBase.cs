namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase<out TValue, out TResult>
{
    void Execute();
    TValue Get();
    TResult GetResult();
    Enum GetCurrentStep();
}