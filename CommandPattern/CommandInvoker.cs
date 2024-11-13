using CommandPattern.Commands.BaseEntities;

namespace CommandPattern;

public class CommandInvoker
{
    private readonly List<CommandResultBase> _commandHistory = new();
    private int _nextId = 1;
    
    public void ExecuteCommand<TCommand, TResult>(TCommand command)
        where TCommand : ICommandBase, ICommandBase<TResult>
    {
        command.Execute();
        var result = command.GetResult();
        var commandResult = new CommandResult<TResult>(command, result);
        _commandHistory.Add(commandResult);
    }
    
    public void UndoSpecificCommand(int commandId)
    {
        var entry = _commandHistory
            .FirstOrDefault(e => e.Command.Id == commandId);

        if (entry == null)
        {
            return;
        }
        
        entry.Command.Undo();
        _commandHistory.Remove(entry);
    }
    
    public int GetNextCommandId()
    {
        return _nextId++;
    }
}