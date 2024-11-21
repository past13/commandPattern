using CommandPattern;
using CommandPattern.Commands.BaseEntities;
using CommandPattern.Commands.DisconnectAction;
using CommandPattern.Serialize;

var commandInvoker = new CommandInvoker<TestBSteps>([]);

var disconnectActionCommand = new DisconnectActionCommand(20);
commandInvoker.ExecuteCommand(disconnectActionCommand);

var connectActionCommand = new ConnectActionCommand(10);
commandInvoker.ExecuteCommand(connectActionCommand);

var history1 = commandInvoker.GetCommandHistory();

var command1 = history1[TestBSteps.DisconnectAction];

var deserializedCommand = SerializableObject.DeserializeCommand(command1.SerializedData, command1.CommandType);

var state = deserializedCommand.GetState();

