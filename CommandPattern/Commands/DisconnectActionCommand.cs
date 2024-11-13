namespace CommandPattern.Commands;

public class DisconnectActionCommand : IDisconnectActionCommand
{
    private int _result;
    public int Id { get; }

    public DisconnectActionCommand(int id)
    {
        Id = id;
    }

    public void Execute()
    {
        _result = 123;
    }

    public void Undo()
    {
        // _textEditor.SetText(_backup);
    }

    public int GetResult()
    {
        return _result;
    }
}