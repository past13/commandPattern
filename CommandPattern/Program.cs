﻿using CommandPattern;
using CommandPattern.Commands.AddText;
using CommandPattern.Commands.DisconnectAction;

var textEditor = new TextEditor();

var commandInvoker = new CommandInvoker([]);

var disconnectActionCommand = new DisconnectActionCommand(20);
commandInvoker.ExecuteCommand(disconnectActionCommand);

var history1 = commandInvoker.GetCommandHistory();

var commandInvoker1 = new CommandInvoker(history1);

var addHelloCommand1 = new AddTextCommand(textEditor, "Well!");
commandInvoker1.ExecuteCommand(addHelloCommand1); 

var history2 = commandInvoker.GetCommandHistory();

foreach (var history in history2)
{
    var test1 = history.Value?.Deserialize();
}

