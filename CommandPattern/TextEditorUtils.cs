namespace CommandPattern;

public class TextEditor
{
    public string Text { get; private set; } = string.Empty;

    public void AddText(string text)
    {
        Text += text;
    }

    public void RemoveText(string text)
    {
        var index = Text.IndexOf(text, StringComparison.Ordinal);
        if (index >= 0)
        {
            Text = Text.Remove(index, text.Length);
        }
    }

    public void SetText(string text)
    {
        Text = text;
    }

    public string GetText()
    {
        return Text;
    }
}