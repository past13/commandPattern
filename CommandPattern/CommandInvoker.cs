using CommandPattern.Commands.BaseEntities;

namespace CommandPattern;

public class CommandInvoker
{
    private readonly Dictionary<HrisSteps, CommandResultBase?> _commandHistory = new();

    public void ExecuteCommand<TCommand, TResult>(TCommand command)
        where TCommand : ICommandBase<TResult>
    {
        command.Execute();

        var currentStep = command.GetCurrentStep();
        var result = command.GetResult();
        _commandHistory[currentStep] = new CommandResult<TResult>(currentStep, result);
    }
}