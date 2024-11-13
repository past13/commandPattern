using CommandPattern;
using CommandPattern.Commands;

var textEditor = new TextEditor();
var commandInvoker = new CommandInvoker();

var addHelloCommand = new AddTextCommand(textEditor, "Hello World!", commandInvoker.GetNextCommandId());
var disconnectActionCommand = new DisconnectActionCommand(commandInvoker.GetNextCommandId());



commandInvoker.ExecuteCommand<AddTextCommand, Result<string>>(addHelloCommand);
commandInvoker.ExecuteCommand<DisconnectActionCommand, Result<int>>(disconnectActionCommand);

commandInvoker.UndoSpecificCommand(addHelloCommand.Id);

var test = "";


