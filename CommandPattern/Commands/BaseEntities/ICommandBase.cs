namespace CommandPattern.Commands.BaseEntities;

public interface ICommandBase
{
    Enum GetCurrentStep();
    bool GetState();
    void Execute();
}