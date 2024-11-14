using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands;

public class AddTextCommand : ICommandBase<string>
{
    private readonly TextEditor _textEditor;
    private readonly string _textToAdd;
    private string _result;

    public int Id { get; }
    
    public AddTextCommand(TextEditor textEditor, string textToAdd)
    {
        _textEditor = textEditor;
        _textToAdd = textToAdd;
    }

    public void Execute()
    {
        _textEditor.AddText(_textToAdd);
    }

    public HrisSteps GetCurrentStep()
    {
        return HrisSteps.AddText;
    }
    
    public string GetResult()
    {
        return _textEditor.GetText();
    }
}