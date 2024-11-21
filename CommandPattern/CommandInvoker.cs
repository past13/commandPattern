using CommandPattern.Commands.BaseEntities;
using CommandPattern.Serialize;

namespace CommandPattern;

public class CommandInvoker<TStep> where TStep : struct, Enum
{
    private readonly Dictionary<TStep, (Type? CommandType, string SerializedData)> _commandHistory;
    public CommandInvoker(Dictionary<TStep, (Type? CommandType, string SerializedData)> commandHistory)
    {
        _commandHistory = commandHistory.Count != 0 
            ? new Dictionary<TStep, (Type? CommandType, string SerializedData)>(commandHistory) 
            : Enum.GetValues<TStep>().
                ToDictionary(step => step, _ => ((Type?)null, ""));
    }

    public void ExecuteCommand(ICommandBase command)
    {
        var commandList = _commandHistory
            .Where(entry => entry.Value.CommandType != null)
            .ToList();
            
        if (commandList.Count != 0)
        {
            var lastCommand = commandList.Last().Value;
            var deserializeCommand = SerializableObject.DeserializeCommand(lastCommand.SerializedData, lastCommand.CommandType);
            if (!deserializeCommand.GetState())
            {
                return;
            }
        }
        
        command.Execute();

        if (Enum.TryParse(typeof(TStep), command.GetCurrentStep().ToString(), out var step))
        {
            var json = SerializableObject.SerializeCommand(command);

            _commandHistory[(TStep)step] = (command.GetType(), json);
        }
        else
        {
            throw new InvalidOperationException($"Invalid step: {command.GetCurrentStep()} for type: {typeof(TStep)}");
        }
    }
    
    public Dictionary<TStep, (Type? CommandType, string SerializedData)> GetCommandHistory()
    {
        return _commandHistory;
    }
}
