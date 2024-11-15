using Newtonsoft.Json;

namespace CommandPattern.Serialize;

public class SerializableObject
{
    private string SerializedData { get; }
    private Type DataType { get; init; }

    public SerializableObject(object obj)
    {
        SerializedData = JsonConvert.SerializeObject(obj);
        DataType = obj.GetType() ?? throw new InvalidOperationException("Type name cannot be null.");
    }

    public object? Deserialize()
    {
        var type = DataType ?? throw new InvalidOperationException($"Unable to resolve type: {nameof(DataType)}");
        return JsonConvert.DeserializeObject(SerializedData, type);
    }
}