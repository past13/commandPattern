using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands;

public class DisconnectActionCommand : ICommandBase<int>
{
    private int _result;
    public int Id { get; }

    public void Execute()
    {
        _result = 123;
    }

    public int GetResult()
    {
        return _result;
    }

    public HrisSteps GetCurrentStep()
    {
        return HrisSteps.DisconnectAction;
    }
}