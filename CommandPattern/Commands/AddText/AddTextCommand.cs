using CommandPattern.Commands.BaseEntities;

namespace CommandPattern.Commands.AddText;

public class AddTextCommand : ICommandBase<string, Result<string>>
{
    private readonly TextEditor _textEditor;
    private readonly string _textToAdd;
    
    private bool _isValid;
    private Result<string> _result;
    private string Value { get; }
    
    public AddTextCommand(TextEditor textEditor, string textToAdd)
    {
        _textEditor = textEditor;
        _textToAdd = textToAdd;
        
        Value = textToAdd;
    }

    private void Validate()
    {
        _isValid = false;
    }

    public void Execute()
    {
        Validate();
        
        if (!_isValid)
        {
            _result = Result<string>.Failure("fail");
            return;
        }
        
        _textEditor.AddText(_textToAdd);
        _result = Result<string>.Success(Value);
    }

    public string Get()
    {
        return Value;
    }
    
    public Enum GetCurrentStep()
    {
        return HrisSteps.AddText;
    }
    
    public Result<string> GetResult()
    {
        return _result;
    }
}