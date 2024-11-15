namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase<out TValue, out TResult>
{
    void Validate();
    void Execute();
    HrisSteps GetCurrentStep();
    TValue Get();
    TResult GetResult();
}
