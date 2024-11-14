using CommandPattern;
using CommandPattern.Commands.AddText;
using CommandPattern.Commands.BaseEntities;
using CommandPattern.Commands.DisconnectAction;

var textEditor = new TextEditor();

var commandInvoker = new CommandInvoker([]);

var disconnectActionCommand = new DisconnectActionCommand(20);
commandInvoker.ExecuteCommand<DisconnectActionCommand, int, Result<int>>(disconnectActionCommand);

var history = commandInvoker.GetCommandHistory();

var commandInvoker1 = new CommandInvoker(history);

var addHelloCommand1 = new AddTextCommand(textEditor, "Well!");
commandInvoker1.ExecuteCommand<AddTextCommand, string, Result<string>>(addHelloCommand1);

var test = 123;

