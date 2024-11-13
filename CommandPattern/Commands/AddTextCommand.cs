namespace CommandPattern.Commands;

public class AddTextCommand : IAddTextCommand
{
    private readonly TextEditor _textEditor;
    private readonly string _textToAdd;
    private string _result;

    public int Id { get; }
    
    public AddTextCommand(TextEditor textEditor, string textToAdd, int id)
    {
        _textEditor = textEditor;
        _textToAdd = textToAdd;
        Id = id;
    }

    public void Execute()
    {
        _result = _textEditor.GetText();
        _textEditor.AddText(_textToAdd);
    }

    public void Undo()
    {
        _textEditor.SetText(_result);
    }

    public string GetResult()
    {
        return _result;
    }
}