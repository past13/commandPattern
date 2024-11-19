using CommandPattern.Commands.BaseEntities;
using CommandPattern.Serialize;

namespace CommandPattern;

public class CommandInvoker<TStep> where TStep : Enum
{
    private readonly Dictionary<TStep, SerializableObject?> _commandHistory;
    public CommandInvoker(Dictionary<TStep, SerializableObject?> commandHistory)
    {
        _commandHistory = commandHistory.Count > 0 ? commandHistory : 
            Enum.GetValues(typeof(TStep))
                .Cast<TStep>()
                .ToDictionary(step => step, SerializableObject? (_) => null);
    }

    public void ExecuteCommand<TValue, TResult>(ICommandBase<TValue, TResult> command)
    {
        command.Execute();

        var resultData = new CommandResult<TValue, TResult>(command.Get(), command.GetResult());
        if (Enum.TryParse(typeof(TStep), command.GetCurrentStep().ToString(), out var step))
        {
            _commandHistory[(TStep)step] = new SerializableObject(resultData);
        }
        else
        {
            throw new InvalidOperationException($"Invalid step: {command.GetCurrentStep()} for type: {typeof(TStep)}");
        }
    }
    
    public Dictionary<TStep, SerializableObject?> GetCommandHistory()
    {
        return _commandHistory;
    }
}
