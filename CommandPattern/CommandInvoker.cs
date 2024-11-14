using CommandPattern.Commands.BaseEntities;

namespace CommandPattern;

public class CommandInvoker
{
    private readonly Dictionary<HrisSteps, ICommandResult?> _commandHistory = new();

    public CommandInvoker(Dictionary<HrisSteps, ICommandResult?> commandHistory)
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
        
        var resultData = new CommandResult<TResult, TValue>(command.GetResult(), command.Get());

        _commandHistory[command.GetCurrentStep()] = resultData;
    }
    
    public Dictionary<HrisSteps, ICommandResult?> GetCommandHistory()
    {
        return _commandHistory;
    }
}