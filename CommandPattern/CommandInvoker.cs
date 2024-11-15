using CommandPattern.Commands.BaseEntities;
using CommandPattern.Serialize;

namespace CommandPattern;

public class CommandInvoker
{
    private readonly Dictionary<HrisSteps, SerializableObject?> _commandHistory = new();
    public CommandInvoker(Dictionary<HrisSteps, SerializableObject?> commandHistory)
    {
        if (commandHistory.Count > 0)
        {
            _commandHistory = commandHistory;
            return;
        }

        foreach (HrisSteps step in Enum.GetValues(typeof(HrisSteps)))
        {
            _commandHistory.Add(step, null);
        }
    }

    public void ExecuteCommand<TCommand, TValue, TResult>(TCommand command)
        where TCommand : ICommandBase<TValue, TResult>
    {
        command.Validate();
        command.Execute();

        var resultData = new CommandResult<TValue, TResult>(command.Get(), command.GetResult());

        _commandHistory[command.GetCurrentStep()] = new SerializableObject(resultData);
    }
    
    public Dictionary<HrisSteps, SerializableObject?> GetCommandHistory()
    {
        return _commandHistory;
    }
}