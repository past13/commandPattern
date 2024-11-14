using CommandPattern;
using CommandPattern.Commands;
using CommandPattern.Commands.BaseEntities;

var stepList = new Dictionary<HrisSteps, CommandResultBase?>();
foreach (HrisSteps step in Enum.GetValues(typeof(HrisSteps)))
{
    stepList.Add(step, null); 
}

var textEditor = new TextEditor();
var commandInvoker = new CommandInvoker();

var addHelloCommand = new AddTextCommand(textEditor, "Hello World!");
var disconnectActionCommand = new DisconnectActionCommand();

commandInvoker.ExecuteCommand<AddTextCommand, string>(addHelloCommand);
commandInvoker.ExecuteCommand<DisconnectActionCommand, int>(disconnectActionCommand);

// commandInvoker.UndoSpecificCommand(addHelloCommand.Id);




var test = "";


