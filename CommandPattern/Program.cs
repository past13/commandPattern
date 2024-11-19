using CommandPattern;
using CommandPattern.Commands.AddText;
using CommandPattern.Commands.BaseEntities;
using CommandPattern.Commands.DisconnectAction;
using CommandPattern.Serialize;


var commandInvoker = new CommandInvoker<TestBSteps>([]);

var disconnectActionCommand = new DisconnectActionCommand(20);
commandInvoker.ExecuteCommand(disconnectActionCommand);

var history1 = commandInvoker.GetCommandHistory();

var commandInvoker1 = new CommandInvoker<TestBSteps>(history1);

var connectActionCommand = new ConnectActionCommand(20);
commandInvoker.ExecuteCommand(connectActionCommand);

var history2 = commandInvoker1.GetCommandHistory();

foreach (var history in history2)
{
    var test1 = history.Value?.Deserialize();
}


var commandHistory1 = new Dictionary<HrisSteps, SerializableObject?>();
var textEditor = new TextEditor();

var commandInvoker2 = new CommandInvoker<HrisSteps>(commandHistory1);

var addHelloCommand = new AddTextCommand(textEditor, "Well!");
commandInvoker2.ExecuteCommand(addHelloCommand); 

var history3 = commandInvoker.GetCommandHistory();

foreach (var history in history3)
{
    var test1 = history.Value?.Deserialize();
}
